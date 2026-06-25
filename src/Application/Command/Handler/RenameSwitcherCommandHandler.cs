using Application.Interface;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    internal class RenameSwitcherCommandHandler : ICommandHandler<RenameSwitcherCommand>
    {
        readonly IWriter _writer;

        public RenameSwitcherCommandHandler(IWriter writer)
        {
            _writer = writer;
        }

        public Task Handle(RenameSwitcherCommand command)
        {
            var switcher = _writer.Read(command.Id);
            if(switcher is  null)
            {
                return Task.CompletedTask;
            }

            var result = switcher.Rename(name: command.Name);
            if (result.IsFailure)
            {

                return Task.CompletedTask;
            }

            _writer.Write(switcher);

            return Task.CompletedTask;
        }
    }
}
