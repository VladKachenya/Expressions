using FilterLogic.Interfaces;

namespace FilterLogic.Heplers
{
    internal struct Operation : IOperation
    {
        public string OperationName { get; set; }
        public bool NeedRight { get; set; }

        public override string ToString()
        {
            return OperationName;
        }
    }
}