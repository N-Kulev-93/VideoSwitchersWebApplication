using Application.Write;

namespace Application.Services
{
    public interface ISwitcherManagedConnectionService
    {
        void OpenConnection(VideoSwitcher switcher);
        void CloseConnection(VideoSwitcher switcher);
    }
}
