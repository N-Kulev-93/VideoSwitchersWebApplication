using System.Linq.Expressions;

namespace Application.Command
{
    internal class VideoSwitcherOutputPositionInRange(int position) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => position > 0 && position <= switcher.Outputs.Count;
        }
    }

}
