namespace Application.Domain
{
    public class VideoSwitcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<VideoInput> Inputs { get; set; }
        public IEnumerable<VideoOutput> Outputs { get; set; }
    }
}
