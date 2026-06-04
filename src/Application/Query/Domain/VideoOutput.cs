namespace Application.Read
{
    public class VideoOutput
    {
        private int SwitcherId { get; set; }
        public required string Name { get; set; }
        public required int Position { get; set; }

        public int? InputPosition { get; set; }
    }
}
