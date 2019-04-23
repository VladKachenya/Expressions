using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public class IntExpressionFormer : ExpressionFormerBase, IExpressionFormer
    {
        public override void Configure(IFilters predictionExpression, Prediction prediction)
        {
            if (prediction.TypeCode == TypeCode.Int32)
            {
                var left = Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);
                var right = Expression.Constant(prediction.RightValue);

                switch (prediction.FilterAtction)
                {
                    case FilterAtction.Less:
                        predictionExpression.Predicts.Add(Expression.LessThan(left, right));
                        return;
                    case FilterAtction.More:
                        predictionExpression.Predicts.Add(Expression.GreaterThan(left, right));
                        return;
                    case FilterAtction.Equal:
                        predictionExpression.Predicts.Add(Expression.Equal(left, right));
                        return;
                }
            }
            else
            {
                base.Configure(predictionExpression, prediction);
            }
        }
    }
}