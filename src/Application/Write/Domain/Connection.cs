using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Read
{
    public class Connection
    {
        public int? Type { get; set; }
        public string? SettingsJSON { get; set; }
        public bool IsOpen { get; set; }
    }
}
