using System;
using FilterLogic.Keys;

namespace FilterLogic.Entities
{
    public class Prediction
    {
        public string PropertyName { get; set; }
        public TypeCode TypeCode { get; set;}
        public FilterAtction FilterAtction { get; set; }
        public object RightValue { get; set; }

        public bool NeedRight()
        {
            return FilterAtction == FilterAtction.Less
                   || FilterAtction == FilterAtction.More
                   || FilterAtction == FilterAtction.Equal;
        }
    }
}