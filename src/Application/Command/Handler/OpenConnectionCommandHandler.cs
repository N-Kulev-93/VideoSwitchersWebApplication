using Application.Interface;
using Application.Services;

namespace Application.Command.Handler
{
    internal class OpenConnectionCommandHandler : ICommandHandler<OpenConnectionCommand>
    {
        readonly ISwitcherWriter _writer;
        readonly IClientConnectionManager _connectionManager;

        public OpenConnectionCommandHandler(ISwitcherWriter writer, IClientConnectionManager connectionManager)
        {
            _writer = writer;
            _connectionManager = connectionManager;
        }

        public Task Handle(OpenConnectionCommand command)
        {
            var switcher = _writer.Read(command.Id);
            if (switcher is null) return Task.CompletedTask; //TODO:

        }
    }
}
