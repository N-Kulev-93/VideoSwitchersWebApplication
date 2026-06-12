using Application.Command;
using System;
namespace Application.Interface
{
    public class PendingChangesToken
    {
        private Func<Task> _commitFunc;
        private Func<Task> _omitFunc;
        public PendingChangesToken(Func<Task> commitFunc, Func<Task> omitFunc)
        {
            _commitFunc = commitFunc;    
        }

        public async Task Commit()
        {
            await _commitFunc();
        }

        public async Task Omit()
        {
            await _omitFunc();
        }
    }

    public interface ISwitcherWriterService
    {
        /// <summary>
        /// Command targeted video switcher.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VideoSwitcher? Read(int id);
        void Write(VideoSwitcher videoSwitcher);
        /// <summary>
        ///  This shoudne be exposed to domain layer, check how to refactor 
        ///  it only on infra level since the transactional logic is infrastructure concern.
        /// </summary>
        /// <param name="videoSwitcher"></param>
        /// <returns></returns>
        Action WriteUncommit(VideoSwitcher videoSwitcher);
    }
}
