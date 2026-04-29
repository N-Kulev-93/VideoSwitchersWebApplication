namespace Application.Command
{
    public class SwitchInputCommand
    {
        public SwitchInputCommand(int switcherId, int inputPosition, int outputPosition)
        {
            SwitcherId = switcherId;
            InputPosition = inputPosition;
            OutputPosition = outputPosition;
        }

        internal int SwitcherId { get; }
        internal int InputPosition { get; }
        internal int OutputPosition { get; }
    }
}
