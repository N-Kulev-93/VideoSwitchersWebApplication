
using Infrastructure.Interface;
using System.Collections.Concurrent;
using Application.Shared;

namespace Infrastructure.Services
{

    internal class ClientConnectionStorage
    {

        readonly ConcurrentDictionary<int, ICommandRuntimeConnection> _map;

        public ClientConnectionStorage()
        {
            _map = new ConcurrentDictionary<int, ICommandRuntimeConnection>();
        }

        public ICommandRuntimeConnection? Get(int clientId)
        {
            return _map.GetValueOrDefault(clientId);
        }

        public void Add(int clientId, ICommandRuntimeConnection connection)
        {
            _map.TryAdd(clientId, connection);
        }

        public ICommandRuntimeConnection? Remove(int clientId)
        {
            return _map.Remove(clientId, out var removed) ? removed : null;
        }
    }

    internal abstract class ClientConnectionService<TConnectionConfiguration> where TConnectionConfiguration : ConnectionConfiguration
    {
        readonly ClientConnectionStorage _storage;

        public ClientConnectionService(ClientConnectionStorage storage)
        {
            _storage = storage;
        }

        public void CloseConnection(int clientId)
        {
            var removed = _storage.Remove(clientId);
            removed?.Close();
        }

        public abstract void OpenConnection(int clientId, TConnectionConfiguration configuration);
    }


    internal class SerialPortConnectionService : ClientConnectionService<SerialPortConfiguration>
    {

    }
}
