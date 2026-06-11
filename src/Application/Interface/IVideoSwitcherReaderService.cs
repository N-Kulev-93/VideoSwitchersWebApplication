using Application.Query;

namespace Application.Interface
{
    public interface IVideoSwitcherReaderService
    {
        IQueryable<VideoSwitcher> Read();
    }
}
