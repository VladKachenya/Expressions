using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IDynamicFilter<T> : IFilterExpression
    {
        Expression<Func<T, bool>> GetLambda();
        IQueryable<T> Filter(List<T> inputList);
    }
}