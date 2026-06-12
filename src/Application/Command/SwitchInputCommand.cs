namespace Application.Command
{
    public class SwitchInputCommand(int id, int inPosition, int outPosition) : ActionCommand
    {
        internal int Id { get; } = id;
        internal int InputPosition { get; } = inPosition;
        internal int OutputPosition { get; } = outPosition;
        public override ActionType ActionType => ActionType.SwitchInput;
    }
}
