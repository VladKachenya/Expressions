using System;

namespace ExpressionConsole.Model
{
    public class SomeData
    {
        public int Id { get; set; }
        public DateTime WorkingDay { get; set; }
        public int SomeIntData { get; set; }
        public float SomeFloatData { get; set; }
        public double SomeDoubleData { get; set; }
        public string SomeSTringData { get; set; }

        public override string ToString()
        {
            string res = "";
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                res = res + propertyInfo.Name + ": " + propertyInfo.GetValue(this) + " ";
            }
            return res;
        }
    }
}