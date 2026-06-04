using Application.Read;

namespace Application.Interface
{
    public interface IVideoSwitcherReaderService
    {
        IQueryable<VideoSwitcher> Read();
    }
}
