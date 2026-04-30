using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public abstract class ActionCommand
    {
        internal abstract ActionType Type { get; }
    }
}
