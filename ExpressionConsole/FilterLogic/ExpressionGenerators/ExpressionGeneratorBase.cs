using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;

namespace FilterLogic.ExpressionGenerators
{
    public abstract class ExpressionGeneratorBase : IExpressionGenerator
    {
        protected Dictionary<string, Func<Expression, Expression, Expression>> _operations = new Dictionary<string, Func<Expression, Expression, Expression>>();

        public Expression GenerateExpression(IFilterExpression filterExpression, Prediction prediction)
        {
            var left = Expression.Property(filterExpression.ParameterExpression, prediction.PropertyName);
            var right = Expression.Constant(prediction.RightValue);
            return _operations[prediction.Operation.OperationName].Invoke(left, right);
        }

        public abstract List<IOperation> GetOperations();
    }
}