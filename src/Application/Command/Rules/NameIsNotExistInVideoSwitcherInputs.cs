using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Command.Rules
{
    internal class NameIsNotExistInVideoSwitcherInputs(string inputName) : Specification<VideoSwitcher>
    {
        public override Expression<Func<VideoSwitcher, bool>> ToExpression()
        {
            return switcher => !switcher.Inputs.Any(input => input.Name.Equals(inputName));
        }
    }
}
