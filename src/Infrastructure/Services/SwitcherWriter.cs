using Application.Interface;
using Application.Command;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    internal class SwitcherWriter : ISwitcherWriter, IDisposable
    {
        readonly SwitchersWriteDbContext _dbContext;

        VideoSwitcher? _currentTarget;

        public SwitcherWriter(SwitchersWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// At writing stage this service is already instantiated with context after the read and before
        /// method execution result so it must be disposed anyway... It should automate the undo of changes
        /// over tracked entity if an action's method performs multiple changes and after some change
        /// validation fails leaving the previous changes in modified state 
        /// (we using result/notification pattern for state) without saving changes(save execution will depend on 
        /// DomainResult outcome) which is the previous frame of an entity method execution.
        /// </summary>
        public void Dispose()
        {
            // TODO: revise and probably refactor... or not ?
            if (_currentTarget is null) return;
            var entry = _dbContext.VideoSwitchers.Entry(_currentTarget);

            if (!entry.State.Equals(EntityState.Modified)) return;
            entry.CurrentValues.SetValues(entry.OriginalValues);

            _dbContext.Dispose();
        }

        public VideoSwitcher? Read(int id)
        {
            _currentTarget = _dbContext.VideoSwitchers.FirstOrDefault(vs => vs.Id.Equals(id));

            return _currentTarget;
        }

        public void Write(VideoSwitcher videoSwitcher)
        {
            _dbContext.VideoSwitchers.Update(videoSwitcher);
            _dbContext.SaveChanges();
        }

        public Action WriteUncommit(VideoSwitcher videoSwitcher)
        {
            _dbContext.VideoSwitchers.Update(videoSwitcher);
            //TODO:...
            return () => _dbContext.SaveChanges();
        }
    }
}
