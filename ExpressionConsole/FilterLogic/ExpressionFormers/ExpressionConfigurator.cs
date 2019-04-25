using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Helpers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.ExpressionFormers
{
    public class ExpressionConfigurator : IExpressionConfigurator
    {
        public Dictionary<Guid, IExpressionFormer> Formers { get; } = new Dictionary<Guid, IExpressionFormer>();

        public void Configure(IFilter predictionExpression, Prediction prediction)
        {
            var expression = Formers[prediction.PropertyType.GUID].FormExpression(predictionExpression, prediction);
            if (expression != null)
            {
                switch (prediction.ConcatenationOperation)
                {
                    case ConcatenationOperation.And:
                        predictionExpression.FinalExpression = Expression.And(predictionExpression.FinalExpression, expression);
                        break;
                    case ConcatenationOperation.Or:
                        predictionExpression.FinalExpression = Expression.Or(predictionExpression.FinalExpression, expression);
                        break;
                }
            }
        }
    }
}