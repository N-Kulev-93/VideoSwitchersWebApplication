using Application.Interface;
using Application.Query;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    internal class SwitcherReaderService : ISwitcherReaderService
    {
        readonly SwitchersReadContext _dbContext;

        public SwitcherReaderService(SwitchersReadContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<VideoSwitcher> Read() => _dbContext.VideoSwitchers.AsNoTracking();
    }
}
