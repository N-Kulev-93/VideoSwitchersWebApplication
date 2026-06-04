using Application.Interface;
using Application.Read;
using Infrastructure.Database;

namespace Infrastructure.Services
{
    internal class VideoSwitcherReaderService : IVideoSwitcherReaderService
    {
        readonly VideoSwitchersReadContext _dbContext;

        public VideoSwitcherReaderService(VideoSwitchersReadContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<VideoSwitcher> Read() => _dbContext.VideoSwitchers;
    }
}
