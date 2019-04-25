namespace FilterLogic.Interfaces
{
    public interface IOperation
    {
        string OperationName { get; set; }
        bool NeedRight { get; set; }
    }
}