using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public class StringExpressionFormer : ExpressionFormerBase
    {
        public StringExpressionFormer()
        {
            _operations.Add(OperationKeys.BeginWithIgnoreCase, (left, right) => ContainsExpression(left, right, true, true) );
            _operations.Add(OperationKeys.BeginWithNotIgnoreCase, (left, right) => ContainsExpression(left, right, true, false));
            _operations.Add(OperationKeys.FinishesOnIgnoreCase, (left, right) => ContainsExpression(left, right, false, true));
            _operations.Add(OperationKeys.FinishesOnNotIgnoreCase, (left, right) => ContainsExpression(left, right, false, true));
        }
        public override List<IOperation> GetOperations()
        {
            var res = new List<IOperation>();
            foreach (var operation in _operations)
            {
                res.Add(new Operation(typeof(string)) { OperationName = operation.Key, NeedRight = true });
            }
            return res;
        }

        protected Expression ContainsExpression(Expression left, Expression right, bool isBeginWith, bool isIgnoreCase)
        {
            if (isIgnoreCase)
            {
                left = Expression.Call(left, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                right = Expression.Call(right, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            }

            Expression indexInExpression;
            Expression expectedIndexExpression;

            if (isBeginWith)
            {
                indexInExpression = Expression.Call(left, typeof(string).GetMethod("IndexOf", new[] { typeof(string) }), right);
                expectedIndexExpression = Expression.Constant(0);
            }
            else
            {
                indexInExpression = Expression.Call(left, typeof(string).GetMethod("LastIndexOf", new[] { typeof(string) }), right);
                expectedIndexExpression = Expression.Subtract(Expression.Property(left, nameof(string.Length)), Expression.Property(right, nameof(string.Length)));
            } 

            return Expression.Equal(indexInExpression, expectedIndexExpression);
        }
    }
}