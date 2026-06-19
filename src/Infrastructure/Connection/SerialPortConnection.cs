using Application.Command;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Connection
{
    internal class SerialPortConnection : ICommandRuntimeConnection
    {
        public bool IsOpen => throw new NotImplementedException();

        public SerialPortConnection(SerialPortConfiguration configuration)
        {
            
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Execute(string command)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}
