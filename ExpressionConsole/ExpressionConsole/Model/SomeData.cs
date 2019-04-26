using System;
using System.Reflection;

namespace ExpressionConsole.Model
{
    public class SomeData
    {
        public int Id { get; set; }
        public int Int { get; set; }
        public string Str { get; set; }
        public DateTime Dow { get; set; }
        public float Float { get; set; }
        public SomeShape Shape { get; set; }

        public override string ToString()
        {
            string res = "";
            foreach (var propertyInfo in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyInfo.PropertyType.GUID == typeof(DateTime).GUID)
                {
                    res = res + propertyInfo.Name + ": " + Dow.DayOfWeek + "\t";
                    continue;
                }
                res = res + propertyInfo.Name + ": " + propertyInfo.GetValue(this) + "\t";
            }
            return res;
        }
    }
}