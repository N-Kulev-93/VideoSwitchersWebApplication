using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Command.Rules
{
    internal class VideoSwitcherOutputPositionInRange(int position) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => position > 0 && position <= switcher.Outputs.Count;
        }
    }

    internal class VideoSwitcherInputPositionInRange(int position) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => position > 0 && position <= switcher.Inputs.Count;
        }
    }
}
