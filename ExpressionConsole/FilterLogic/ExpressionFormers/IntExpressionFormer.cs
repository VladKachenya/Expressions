using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public class IntExpressionFormer : IExpressionFormer
    {
        public Expression FormExpression(IFilter predictionExpression, Prediction prediction)
        {
            var left = Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);
            var right = Expression.Constant(prediction.RightValue);

            switch (prediction.Operation)
            {
                case Operation.Less:
                    return Expression.LessThan(left, right);
                case Operation.More:
                    return Expression.GreaterThan(left, right);
                case Operation.Equal:
                    return Expression.Equal(left, right);
            }
            return null;
        }
    }
}