using Application.Command;

namespace Application.Services
{
    public interface IClientConnectionManager
    {
        void OpenConnection(int clientId, ConnectionConfiguration configuration);
        void CloseConnection(int clientId);
    }
}
