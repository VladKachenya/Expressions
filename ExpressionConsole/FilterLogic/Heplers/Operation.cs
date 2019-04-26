using System;
using FilterLogic.Interfaces;

namespace FilterLogic.Heplers
{
    public class Operation: IOperation
    {
        public Operation(Type operandType)
        {
            OperandType = operandType;
        }
        public string OperationName { get; set; }
        public Type OperandType { get; }
        public bool NeedRight { get; set; }

        public override string ToString()
        {
            return $"Operation: {OperationName} ({OperandType.Name})";
        }
    }
}