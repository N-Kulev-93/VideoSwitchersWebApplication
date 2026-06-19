using Application.Interface;
using Application.Query;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    internal class SwitcherReaderService : ISwitcherReader
    {
        readonly SwitchersReadDbContext _dbContext;

        public SwitcherReaderService(SwitchersReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<VideoSwitcher> Read() => _dbContext.VideoSwitchers.AsNoTracking();
    }
}
