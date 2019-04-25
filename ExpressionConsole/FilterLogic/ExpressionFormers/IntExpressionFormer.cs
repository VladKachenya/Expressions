using System.Collections.Generic;
using FilterLogic.Helpers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System.Linq.Expressions;
using FilterLogic.Heplers;

namespace FilterLogic.ExpressionFormers
{
    public class IntExpressionFormer : ExpressionFormerBase, IExpressionFormer
    {
        public IntExpressionFormer()
        {
            _operations.Add(OperationKeys.LessKey, expression => Expression.LessThan(expression[0], expression[1]));
            _operations.Add(OperationKeys.MoreKey, expression => Expression.GreaterThan(expression[0], expression[1]));
            _operations.Add(OperationKeys.EqualKey, expression => Expression.Equal(expression[0], expression[1]));
        }
        public Expression FormExpression(IFilter predictionExpression, Prediction prediction)
        {
            var left = Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);
            var right = Expression.Constant(prediction.RightValue);
            return _operations[prediction.Operation.OperationName].Invoke(new Expression[] { left, right});
        }

        public List<Operation> GetOperations()
        {
            var res = new List<Operation>();
            foreach (var operation in _operations)
            {
                res.Add(new Operation() { OperationName = operation.Key, NeedRight = true});
            }
            return res;
        }
    }
}