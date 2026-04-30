namespace Application.Command
{
    public class VideoOutput
    {
        public required int Position { get; set; }
        public required string Name { get; set; }
        public required int SwitcherId { get; set; }
        public int? InputPosition { get; set; }
    }
}
