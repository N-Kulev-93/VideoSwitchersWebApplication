using Application.Services;
using Application.Write;
using Application.Write.Domain;
using Infrastructure.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{

    //TODO: Dispose all connections on app termination ?
    internal class SwitcherRuntimeConnectionService : ISwitcherManagedConnectionService, ISwitcherConnectionStatusService, ISwitcherConnectionProviderService
    {
        readonly ConcurrentDictionary<int, IRuntimeCommandConnection> _switcherConnectionMap;

        public SwitcherRuntimeConnectionService()
        {
            _switcherConnectionMap = new ConcurrentDictionary<int, IRuntimeCommandConnection>();        
        }

        public void CloseConnection(VideoSwitcher switcher)
        {
            throw new NotImplementedException();
        }

        public void OpenConnection(VideoSwitcher switcher)
        {
            throw new NotImplementedException();
        }

        public bool HasOpenConnection(int switcherId)
        {
            return _switcherConnectionMap.TryGetValue(key: switcherId, out IRuntimeCommandConnection? connection) && connection.IsOpen;
        }

        public IRuntimeCommandConnection? GetCommandConnection(int switcherId)
        {
            return _switcherConnectionMap.GetValueOrDefault(key: switcherId);
        }

    }
}
