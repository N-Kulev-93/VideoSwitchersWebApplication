namespace Application.Command
{
    public class RenameInputCommand
    {
        public RenameInputCommand(int switcherId, int position, string name)
        {
            SwitcherId = switcherId; 
            Position = position;
            Name = name;
        }

        internal int SwitcherId { get; }
        internal int Position { get; }
        internal string Name { get; }
    }
}
