using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command.Domain
{
    public interface IManagedConnection
    {
        void Open();
        bool IsOpen { get; }
        void Close();
    }
}
