using Application.Write;

namespace Application.Command
{
    public class RenameSwitcherInputCommand(int id, int position, string name) : ActionCommand
    {
        internal int Id { get; } = id;
        internal int Position { get; } = position;
        internal string Name { get; } = name;

        public override ActionType ActionType => ActionType.RenameInput;
    }
}
