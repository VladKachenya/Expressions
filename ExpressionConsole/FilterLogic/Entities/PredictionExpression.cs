using FilterLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.Entities
{
    public class PredictionExpression<T> : IPredictionExpression<T>
    {
        public PredictionExpression()
        {
            ParameterExpression = Expression.Parameter(typeof(T), "data");
            Predicts = new List<Expression>();
        }
        public ParameterExpression ParameterExpression { get; set; }
        public List<Expression> Predicts { get; }
        public Expression<Func<T, bool>> GetLambda()
        {
            var finalPredict = GetDummy();
            foreach (var predict in Predicts)
            {
                finalPredict = Expression.And(finalPredict, predict);
            }
            return Expression.Lambda<Func<T, bool>>(finalPredict, new ParameterExpression[] { ParameterExpression });
        }

        private Expression GetDummy()
        {
            var constOne = Expression.Constant(1);
            return Expression.Equal(constOne, constOne);
        }
    }
}