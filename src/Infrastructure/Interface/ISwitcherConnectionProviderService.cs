using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    internal interface ISwitcherConnectionProviderService
    {
        IRuntimeCommandConnection? GetCommandConnection(int switcherId);
    }
}
