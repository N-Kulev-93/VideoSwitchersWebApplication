using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    internal interface IClientConnectionStatusService
    {
        bool ContainsConnection(int switcherId);
    }
}
