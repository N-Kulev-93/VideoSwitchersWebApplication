using Application.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Read
{
    public class VideoSwitcher
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required IEnumerable<VideoInput> Inputs { get; set; }
        public required IEnumerable<VideoOutput> Outputs { get; set; }

        public required ConnectionConfiguration ConnectionConfiguration { get; set; }
        public required bool ConnectionOpen { get; set; }

        public required IEnumerable<ActionConfiguration> ActionConfigurations { get; set; }
    }
}
