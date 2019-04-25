using System;
using FilterLogic.Heplers;
using FilterLogic.Keys;

namespace FilterLogic.Helpers
{
    public class Prediction
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set;}
        public Operation Operation { get; set; }
        public ConcatenationOperation ConcatenationOperation { get; set; }
        public object RightValue { get; set; }
    }
}