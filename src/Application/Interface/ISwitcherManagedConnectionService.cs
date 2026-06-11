using Application.Command;

namespace Application.Services
{
    public interface ISwitcherManagedConnectionService
    {
        void OpenConnection(VideoSwitcher switcher);
        void CloseConnection(VideoSwitcher switcher);
    }
}
