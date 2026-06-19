using Application.Command;
using Infrastructure.Connection;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    internal static class CommandConnectionFactory
    {
        internal static ICommandRuntimeConnection Create(ConnectionConfiguration configuration)
        {
            switch (configuration.ConnectionType)
            {
                case ConnectionType.SerialPort: return new SerialPortConnection(configuration.ToSerialPort());
                case ConnectionType.Telnet: throw new NotImplementedException();
                case ConnectionType.Api: throw new NotImplementedException();
                case ConnectionType.None:
                default: throw new ArgumentException();
            }
        }
    }
}
