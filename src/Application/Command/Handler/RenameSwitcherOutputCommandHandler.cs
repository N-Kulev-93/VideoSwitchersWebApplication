using Application.Interface;

namespace Application.Command.Handler
{
    internal class RenameSwitcherOutputCommandHandler : ICommandHandler<RenameSwitcherOutputCommand>
    {

        readonly IWriter _writer;

        public RenameSwitcherOutputCommandHandler(IWriter writer)
        {
            _writer = writer;
        }

        public Task Handle(RenameSwitcherOutputCommand command)
        {
            var switcher = _writer.Read(command.Id);
            if (switcher is null)
            {
                return Task.CompletedTask;
            }

            var result = switcher.RenameOutput(command.Position, command.Name);
            if (result.IsFailure)
            {

                /// maybe manual revert here ??
                return Task.CompletedTask;
            }

            _writer.Write(switcher);

            return Task.CompletedTask;
        }
    }
}
