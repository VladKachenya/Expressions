using System;
using System.Collections.Generic;

namespace ExpressionConsole.Model
{
    public static class SomeDataFactory
    {
        static Random rand = new Random();

        public static List<SomeData> GetRandomSomeData()
        {
            var res = new List<SomeData>();

            for (int i = 0; i < 10; i++)
            {
                var round = new SomeData()
                {
                    Id = i,
                    WorkingDay = DateTime.Now.AddDays(rand.Next(8)),
                    SomeIntData = rand.Next(10),
                    SomeFloatData = (float)((rand.NextDouble() * 2.0 - 1.0) * (Math.Pow(2.0, rand.Next(-126, 128)))),
                    //SomeDoubleData = (rand.NextDouble() * 2.0 - 1.0) * (Math.Pow(2.0, rand.Next(-126, 128))),
                    SomeSTringData = "someProp" + rand.Next(10),
                    //Views = rand.Next(10),
                    //Start = DateTime.Now.AddDays(rand.Next(8)),
                    //End = DateTime.Now.AddDays(rand.Next(8))
                };
                res.Add(round);
            }
            return res;
        }
    }
}