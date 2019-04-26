using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionConsole.Model
{
    public static class SomeDataFactory
    {
        private static Random rand = new Random();

        public static List<SomeData> GetRandomSomeData()
        {
            var res = new List<SomeData>();
            int count = 20;

            for (int i = 0; i < count; i++)
            {
                var data = new SomeData()
                {
                    Id = i,
                    Dow = DateTime.Now.AddDays(rand.Next(8)),
                    Int = rand.Next(10),
                    Float = (float)Math.Round(rand.NextDouble(), 2),
                    Str = "body" + rand.Next(10),
                    Shape = new SomeShape(rand.Next(100), rand.Next(100), GetRandomShape())
                };
                if (i >= rand.Next(count))
                {
                    data.Str = "L" + data.Str;
                }

                if (i <= rand.Next(count))
                {
                    data.Str = data.Str + "L";
                }

                res.Add(data);
            }
            return res;
        }
        private static Shapes GetRandomShape()
        {
            var values = Enum.GetValues(typeof(Shapes));
            return values.Cast<Shapes>().ToList()[rand.Next(values.Length)];
        }
    }

    
}