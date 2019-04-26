using System;
using System.Collections.Generic;
using FilterLogic.Helpers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System.Linq.Expressions;
using FilterLogic.Heplers;

namespace FilterLogic.ExpressionFormers
{
    public class NumberExpressionFormer: ExpressionFormerBase
    {
        private readonly Type _operandType;

        public NumberExpressionFormer(Type operandType) 
        {
            _operandType = operandType;
            _operations.Add(OperationKeys.LessKey, Expression.LessThan);
            _operations.Add(OperationKeys.MoreKey, Expression.GreaterThan);
            _operations.Add(OperationKeys.EqualKey, Expression.Equal);
        }
        
        public override List<IOperation> GetOperations()
        {
            var res = new List<IOperation>();
            foreach (var operation in _operations)
            {
                res.Add(new Operation(_operandType) { OperationName = operation.Key, NeedRight = true});
            }
            return res;
        }
    }
}