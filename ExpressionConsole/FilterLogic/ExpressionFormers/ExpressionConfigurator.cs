using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.ExpressionFormers
{
    public class ExpressionConfigurator : IExpressionConfigurator
    {
        public Dictionary<Type, IExpressionFormer> Formers { get; } = new Dictionary<Type, IExpressionFormer>();

        public void Configure(IFilter predictionExpression, Prediction prediction)
        {
            var expression = Formers[prediction.PropertyType].FormExpression(predictionExpression, prediction);
            if (expression != null)
            {
                switch (prediction.ConcatenationOperation)
                {
                    case Operation.And:
                        predictionExpression.FinalExpression = Expression.And(predictionExpression.FinalExpression, expression);
                        break;
                    case Operation.Or:
                        predictionExpression.FinalExpression = Expression.Or(predictionExpression.FinalExpression, expression);
                        break;
                }
            }
        }
    }
}