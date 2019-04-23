using System;
using System.Collections.Generic;

namespace FilterLogic.Model
{
    public class SomeDataFactory
    {
        Random rand = new Random();

        public List<SomeData> GetRandomSomeData()
        {
            var res = new List<SomeData>();

            for (int i = 0; i < 10; i++)
            {
                var round = new SomeData()
                {
                    Id = i,
                    //Steps = rand.Next(10),
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