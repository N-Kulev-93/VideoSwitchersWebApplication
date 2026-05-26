using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Write.Domain
{
    public interface IConnection
    {
        void Open(string settingsJSON);
        void Close();
        bool IsOpen { get; }
        void ChangeType(ConnectionType type);
    }
}
