using System;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.Heplers
{
    public class Prediction
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set;}
        public IOperation Operation { get; set; }
        public ConcatenationOperation ConcatenationOperation { get; set; }
        public bool IsInvers { get; set; }
        public object RightValue { get; set; }
    }
}