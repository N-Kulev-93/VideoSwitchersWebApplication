using Application.Interface;
using Application.Write;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{

    internal class VideoSwitcherWriterService : IVideoSwitcherWriterService, IDisposable
    {
        readonly VideoSwitchersWriteContext _dbContext;
        VideoSwitcher? _currentTarget;

        public VideoSwitcherWriterService(VideoSwitchersWriteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            if (_currentTarget is null) return;
            var entry = _dbContext.VideoSwitchers.Entry(_currentTarget);

            if (!entry.State.Equals(EntityState.Modified)) return;
            entry.CurrentValues.SetValues(entry.OriginalValues);
        }

        public VideoSwitcher? ReadSingle(int id)
        {
            _currentTarget = _dbContext.VideoSwitchers.FirstOrDefault(vs => vs.Id.Equals(id));

            return _currentTarget;
        }

        public void Write(VideoSwitcher videoSwitcher)
        {
            _dbContext.VideoSwitchers.Update(videoSwitcher);
            _dbContext.SaveChanges();
        }

        public Task<PendingChangesToken> WritePendingAsync(VideoSwitcher videoSwitcher)
        {
            throw new NotImplementedException();
        }
    }
}
