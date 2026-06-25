
using Application.Query.Domain.Settings;

namespace Application.Query
{
    public class VideoSwitcher
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required IEnumerable<VideoInput> Inputs { get; set; }
        public required IEnumerable<VideoOutput> Outputs { get; set; }
        public required SwitcherSettings Settings { get; set; }
        public bool IsOnline { get; set; }
    }
}
