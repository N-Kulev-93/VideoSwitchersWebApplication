using Application.Query;

namespace Application.Interface
{
    public interface ISwitcherReader
    {
        IQueryable<VideoSwitcher> Read();
    }
}
