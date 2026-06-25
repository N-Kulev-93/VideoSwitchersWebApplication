using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Command
{
    internal class NameIsNotExistInVideoSwitcherOutputs(string value) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => !switcher.Outputs.Any(output => output.Name.Equals(value));
        }
    }
}
