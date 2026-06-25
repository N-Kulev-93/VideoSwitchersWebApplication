using System.Linq.Expressions;

namespace Application.Command
{
    internal class VideoSwitcherInputPositionInRange(int position) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => position > 0 && position <= switcher.Inputs.Count;
        }
    }
}
