namespace Application.Command
{
    public class RenameOutputCommand : ActionCommand
    {
        public RenameOutputCommand(int switcherId, int position, string name)
        {
            SwitcherId = switcherId;
            Position = position;
            Name = name;
        }

        internal int SwitcherId { get; }
        internal int Position { get; }
        internal string Name { get; }
        internal override ActionType Type { get; } = ActionType.RenameOutput;
    }
}
