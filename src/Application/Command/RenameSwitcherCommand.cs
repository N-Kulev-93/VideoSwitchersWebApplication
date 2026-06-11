using Application.Command;

namespace Application.Command
{
    public class RenameSwitcherCommand(int id, string name) : ActionCommand
    {
        internal int Id { get; } = id;
        internal string Name { get; } = name;
        
        public override ActionType ActionType => ActionType.RenameSwitcher;
    }
}
