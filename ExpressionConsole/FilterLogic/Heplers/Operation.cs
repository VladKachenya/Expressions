using System;
using FilterLogic.Interfaces;

namespace FilterLogic.Heplers
{
    public class Operation<T> : IOperation
    {
        public string OperationName { get; set; }
        public Type OperandType => typeof(T);
        public bool NeedRight { get; set; }

        public override string ToString()
        {
            return $"Operation: {OperationName} ({OperandType.Name})";
        }
    }
}