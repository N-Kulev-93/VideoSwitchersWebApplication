namespace Application.Command
{
    public class RenameSwitcherCommand : ActionCommand
    {
        public RenameSwitcherCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        internal int Id { get; }
        internal string Name { get; }
        internal override ActionType Type { get; } = ActionType.RenameSwitcher;
    }
}
