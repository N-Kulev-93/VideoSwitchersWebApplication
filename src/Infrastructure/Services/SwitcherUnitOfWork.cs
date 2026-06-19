using Application.Command;
using Application.Interface;
using Infrastructure.Database;
using Infrastructure.Interface;

namespace Infrastructure.Services
{
    /// <summary>
    /// If action should be directly writed or executed on actual 
    /// device and then writed must(right?, open to discussion about it..) be
    /// decided on domain side since is part of the project's features.
    /// Actions supported by switcher device and enabled by configuration and their post action state
    /// should be persisted atomicaly with the device's corresponding device command(as RS-232 or Telnet command, not application CQRS...)
    /// If device command fails we should not persist the domain model state and remain synced on both sides(database and device).
    /// </summary>
    internal class SwitcherUnitOfWork : ISwitcherUnitOfWork, IDisposable
    {
        readonly ISwitcherWriter _writer;
        readonly IClientCommandConnectionProviderService _connectionProvider;

        /// <summary>
        /// TODO: how to correctly instantiate unit of work on domain level(execution of action) 
        /// and pass already instantiated writer and a connection provider(not instantiated, it will always happen on infra level).
        /// Temporary decision the command execution service that is instantiated with DI dynamically will provide it with direct DI injection 
        /// or some provider .... 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="connectionProvider"></param>
        public SwitcherUnitOfWork(ISwitcherWriter writer, IClientCommandConnectionProviderService connectionProvider)
        {
            _writer = writer;
            _connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Current plan is unit of work is created after already instanciated writer and performed writer read operation returning 
        /// switcher configured with action to be perfomerd on actual device so we can reuse the writer instance and create unit of work 
        /// based on configuration ...
        /// </summary>
        public void Dispose()
        {
            //TODO: do we need this .. ?
        }

        /// <summary>
        /// Writes updated state of an action configured as enabled on device that is supposed
        /// to support it using transaction for actual device execution and state persisting.
        /// </summary>
        /// <param name="videoSwitcher"></param>
        /// <param name="action"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteAction(VideoSwitcher videoSwitcher, ActionType action)
        {
            var connection = _connectionProvider.Get(id: videoSwitcher.Id);

            // since its expected to have open connection always how we handle it, use exceptions or return boolean result  ? TODO:...
            if (connection is null) throw new Exception("TODO:...");
            var command = SwitcherActionCommandFormatter.Format(videoSwitcher, action);

            try
            {
                var commitAction = _writer.WriteUncommit(videoSwitcher);

                // For now this is expected to throw but can be refactored with booleans to skip exceptions for flow control.
                connection.Execute(command);

                commitAction();
            }
            catch (Exception ex)
            {

                //TODO: log + ...
            }
        }
    }
}
