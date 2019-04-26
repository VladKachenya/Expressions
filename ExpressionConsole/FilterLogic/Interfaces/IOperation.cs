using System;

namespace FilterLogic.Interfaces
{
    public interface IOperation
    {
        string OperationName { get; set; }
        Type OperandType { get;}
        bool NeedRight { get; set; }
    }
}