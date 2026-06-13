using Application.Command;

namespace Application.Interface
{
    public interface ISwitcherActionWriterUnitOfWork
    {
        /// <summary>
        /// Persist video switcher.
        /// </summary>
        /// <param name="videoSwitcher"></param>
        /// <returns></returns>
        void WriteAction(VideoSwitcher videoSwitcher, ActionType action);
    }
}
