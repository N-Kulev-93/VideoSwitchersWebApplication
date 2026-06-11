using Application.Command;

namespace Application.Command
{
    public abstract class ActionCommand
    {
        public abstract ActionType ActionType { get; }
    }
}
