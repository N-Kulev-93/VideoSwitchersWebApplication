using Application.Interface;

namespace Application.Services
{
    public interface IClientCommunicationStorage
    {
        ICommunicationSource? GetOrNull(int clientId);
        ICommunicationSource GetOrAdd(int clientId, Func<ICommunicationSource> onAddSourceFactory);    
        ICommunicationSource? Remove(int clientId);
    }
}
