using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Write
{
    public class ActionConfiguration
    {
        public ActionType Type { get; set; }
        public string? CommandTemplate { get; set; }
        public bool Enabled { get; set; }
    }
}
