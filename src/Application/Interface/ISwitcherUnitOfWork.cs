using Application.Command;

namespace Application.Interface
{
    public interface ISwitcherUnitOfWork
    {
        /// <summary>
        /// Persist video switcher.
        /// </summary>
        /// <param name="videoSwitcher"></param>
        /// <returns></returns>
        void WriteAction(VideoSwitcher videoSwitcher, ActionType action);
    }
}
