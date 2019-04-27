using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.ExpressionGenerators
{
    public class NumberExpressionGenerator: ExpressionGeneratorBase
    {
        private readonly Type _operandType;

        public NumberExpressionGenerator(Type operandType) 
        {
            _operandType = operandType;
            _operations.Add(OperationKeys.Less, Expression.LessThan);
            _operations.Add(OperationKeys.More, Expression.GreaterThan);
            _operations.Add(OperationKeys.Equal, Expression.Equal);
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