using Application.Interface;
using Application.Services;

namespace Application.Command.Handler
{
    internal class CloseSwitcherCommunicationSourceCommand : ICommandHandler<Command.CloseSwitcherCommunicationSourceCommand>
    {
        readonly IClientCommunicationStorage _clientCommunicationStorage;
        
        public CloseSwitcherCommunicationSourceCommand(IClientCommunicationStorage clientCommunicationStorage)
        {
            _clientCommunicationStorage = clientCommunicationStorage;
        }

        public Task Handle(Command.CloseSwitcherCommunicationSourceCommand command)
        {
            var source = _clientCommunicationStorage.Remove(command.Id);
            
            if (source is null)
            {
                return Task.CompletedTask;
            }
            source.Close();

            return Task.CompletedTask;
        }
    }
}
