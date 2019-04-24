using System;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IPredictionExpression<T> : IFilter
    {
        Expression<Func<T, bool>> GetLambda();
    }
}