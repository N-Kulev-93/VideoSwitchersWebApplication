using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    internal interface ISwitcherConnectionStatusService
    {
        bool HasOpenConnection(int switcherId);
    }
}
