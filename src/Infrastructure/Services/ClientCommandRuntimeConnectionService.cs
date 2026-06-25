
using Infrastructure.Interface;
using System.Collections.Concurrent;
using Application.Interface;

namespace Infrastructure.Services
{

    internal class ClientConnectionStorage
    {


        readonly ConcurrentDictionary<int, ICommunicationSource> _map;

        public ClientConnectionStorage()
        {
            _map = new ConcurrentDictionary<int, ICommunicationSource>();
        }

        public ICommunicationSource? Get(int clientId)
        {
            return _map.GetValueOrDefault(clientId);
        }

        public void Add(int clientId, ICommunicationSource connection)
        {
            _map.TryAdd(clientId, connection);
        }

        public ICommunicationSource? Remove(int clientId)
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
