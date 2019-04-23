using System;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IPredictionExpression<T> : IFilters
    {

        Expression<Func<T, bool>> GetLambda();
    }
}