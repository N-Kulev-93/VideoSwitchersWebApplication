using Application.Write;

namespace Application.Services
{
    public interface ISwitcherManagedConnectionService
    {
        void OpenConnection(int switcherId, ConnectionConfiguration configuration);
        void CloseConnection(int switcherId);
    }
}
