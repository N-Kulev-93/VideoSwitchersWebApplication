using Application.Query;

namespace Application.Interface
{
    public interface ISwitcherReaderService
    {
        IQueryable<VideoSwitcher> Read();
    }
}
