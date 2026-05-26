using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Read
{
    public class VideoInput
    {
        private int SwitcherId { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public required string Name { get; set; }
        public required int Position { get; set; }
    }
}
