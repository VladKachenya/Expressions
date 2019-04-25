using FilterLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FilterLogic.Helpers
{
    internal class DynamicFilter<T> : IDynamicFilter<T>
    {
        public DynamicFilter()
        {
            ParameterExpression = Expression.Parameter(typeof(T), "data");
            var constOne = Expression.Constant(1);
            FinalExpression = Expression.Equal(constOne, constOne);
        }
        public ParameterExpression ParameterExpression { get; set; }
        public BinaryExpression FinalExpression { get; set; }

        public Expression<Func<T, bool>> GetLambda()
            => Expression.Lambda<Func<T, bool>>(FinalExpression, ParameterExpression);

        public IQueryable<T> Filter(List<T> inputList)
            => inputList.AsQueryable().Where(GetLambda());
    }
}
