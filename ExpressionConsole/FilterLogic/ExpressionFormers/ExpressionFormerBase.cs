using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public abstract class ExpressionFormerBase : IExpressionFormer
    {
        protected Dictionary<string, Func<Expression, Expression, Expression>> _operations = new Dictionary<string, Func<Expression, Expression, Expression>>();

        public Expression FormExpression(IPredictionExpression predictionExpression, Prediction prediction)
        {
            var left = Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);
            var right = Expression.Constant(prediction.RightValue);
            return _operations[prediction.Operation.OperationName].Invoke(left, right);
        }

        public abstract List<IOperation> GetOperations();
    }
}