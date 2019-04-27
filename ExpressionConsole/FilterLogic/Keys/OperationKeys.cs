namespace FilterLogic.Keys
{
    internal class OperationKeys
    {
        //for int
        public const string Less =nameof(Less);
        public const string More = nameof(More);
        public const string Equal = nameof(Equal);
        //for DateTime
        public const string Workday = nameof(Workday);
        public const string Holiday = nameof(Holiday);
        //for string
        public const string BeginWithIgnoreCase = nameof(BeginWithIgnoreCase);
        public const string BeginWithNotIgnoreCase = nameof(BeginWithNotIgnoreCase);
        public const string FinishesOnIgnoreCase = nameof(FinishesOnIgnoreCase);
        public const string FinishesOnNotIgnoreCase = nameof(FinishesOnNotIgnoreCase);
    }
}