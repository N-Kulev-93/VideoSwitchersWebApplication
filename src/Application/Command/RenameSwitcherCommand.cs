namespace Application.Command
{
    public class RenameSwitcherCommand
    {
        public RenameSwitcherCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        internal int Id { get; }
        internal string Name { get; }
    }
}
