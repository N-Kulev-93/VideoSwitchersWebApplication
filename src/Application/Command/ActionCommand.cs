using Application.Write;

namespace Application.Command
{
    public abstract class ActionCommand
    {
        public abstract ActionType ActionType { get; }
    }
}
