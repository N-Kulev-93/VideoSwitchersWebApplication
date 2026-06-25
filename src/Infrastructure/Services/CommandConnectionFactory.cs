using Application.Command.Domain.Settings;
using Infrastructure.Connection;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    internal static class CommandConnectionFactory
    {
        internal static ICommunicationSource Create(CommunicationSettings configuration)
        {
            switch (configuration.ConnectionType)
            {
                case CommunicationType.SerialPort: return new SerialPortConnection(configuration.ToSerialPort());
                case CommunicationType.Telnet: throw new NotImplementedException();
                case CommunicationType.Api: throw new NotImplementedException();
                case CommunicationType.None:
                default: throw new ArgumentException();
            }
        }
    }
}
