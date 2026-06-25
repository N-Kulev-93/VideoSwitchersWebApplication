using Application.Interface;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command.Handler
{
    internal class RenameSwitcherInputCommandHandler : ICommandHandler<RenameSwitcherInputCommand>
    {

        readonly IWriter _writer;
        readonly IClientCommunicationStorage _clientCommunicationStorage;

        public RenameSwitcherInputCommandHandler(IWriter writer, IClientCommunicationStorage connectionManager)
        {
            _writer = writer;
            _clientCommunicationStorage = connectionManager;
        }

        public Task Handle(RenameSwitcherInputCommand command)
        {
            var switcher = _writer.Read(command.Id);
            if (switcher is null)
            {
                return Task.CompletedTask;
            }

            var result = switcher.RenameInput(command.Position, command.Name);
            if (result.IsFailure)
            {

                return Task.CompletedTask;
            }

            _writer.Write(switcher);

            return Task.CompletedTask;
        }
    }
}
