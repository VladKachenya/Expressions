using FilterLogic.Interfaces;
using System;
using System.Linq.Expressions;

namespace FilterLogic.Helpers
{
    public class Filter<T> : IPredictionExpression<T>
    {
        public Filter()
        {
            ParameterExpression = Expression.Parameter(typeof(T), "data");
            var constOne = Expression.Constant(1);
            FinalExpression = Expression.Equal(constOne, constOne);
        }
        public ParameterExpression ParameterExpression { get; set; }
        public BinaryExpression FinalExpression { get; set; }

        public Expression<Func<T, bool>> GetLambda() 
            => Expression.Lambda<Func<T, bool>>(FinalExpression, ParameterExpression);
    }

}
