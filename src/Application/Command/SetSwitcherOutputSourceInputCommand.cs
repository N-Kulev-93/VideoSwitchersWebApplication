using Application.Interface;

namespace Application.Command
{
    public class SetSwitcherOutputSourceInputCommand(int id, int inPosition, int outPosition) : ICommand
    {
        internal int Id { get; } = id;
        internal int InputPosition { get; } = inPosition;
        internal int OutputPosition { get; } = outPosition;
    }
}
