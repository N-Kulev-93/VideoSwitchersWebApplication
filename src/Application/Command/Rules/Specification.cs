using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Write.Rules
{
    internal abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {

            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }
    }
}
