using System;
using FilterLogic.Keys;

namespace FilterLogic.Entities
{
    public class Prediction
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set;}
        public Operation Operation { get; set; }
        public Operation ConcatenationOperation { get; set; }
        public object RightValue { get; set; }

        public bool NeedRight()
        {
            return Operation == Operation.Less
                   || Operation == Operation.More
                   || Operation == Operation.Equal;
        }
    }
}