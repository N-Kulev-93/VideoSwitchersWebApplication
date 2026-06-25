using Application.Interface;
using Application.Services;
using Application.Shared;
using Application.Shared.Domain;

namespace Application.Command.Handler
{
    internal class OpenSwitcherCommunicationSourceCommand : ICommandHandler<OpenSwitcherCommunicationCommand>
    {
        readonly IWriter _switcherWriter;
        readonly IClientCommunicationStorage _clientCommunicationStorage;
        readonly Func<CommunicationSettings, ICommunicationSource> _sourceFactory = (settings) =>
        {
            if (settings.Type.Equals(CommunicationType.SerialPort))
            return new 
        }
        public OpenSwitcherCommunicationSourceCommand(IWriter writer, IClientCommunicationStorage connectionManager)
        {
            _writer = writer;
            _clientCommunicationStorage = connectionManager;
        }

        public Task Handle(OpenSwitcherCommunicationCommand command)
        {
            var switcher = _writer.Read(command.Id);
            if (switcher is null)
            {
                return Task.CompletedTask;
            }
            var communicationType = switcher.Settings.Communication.Type;

            var source = _clientCommunicationStorage.GetOrAdd(command.Id, () =>
            {
                if (type is CommunicationType.SerialPort)
                {
                    return 
                }
            })
            if (switcher.ActionsConnection.IsOpen)
            {
                return Task.CompletedTask;
            }

            var communicationType = switcher.ActionsConnection.Type;
            switch (communicationType)
            {
                case CommunicationType.SerialPort: retu
            }
            if(communicationType is CommunicationType.SerialPort)
            var source = _clientCommunicationStorage.GetOrAdd(command.Id, )
        }
    }
}
