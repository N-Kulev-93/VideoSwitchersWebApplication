using Application.Shared.Domain;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Connection
{
    internal class SerialPortConnection : ICommunicationSource
    {
        public bool IsAlive => throw new NotImplementedException();

        public SerialPortConnection(SerialPortSettings configuration)
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
