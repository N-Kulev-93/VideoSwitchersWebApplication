using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Write.Domain
{
    public interface IManagedConnection
    {
        void Open();
        bool IsOpen { get; }
        void Close();
    }
}
