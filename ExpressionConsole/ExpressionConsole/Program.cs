using ExpressionConsole.Model;
using FilterLogic;
using FilterLogic.Heplers;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //GetSomeData
            var someDatas = SomeDataFactory.GetRandomSomeData();
            foreach (var data in someDatas)
            {
                Console.WriteLine(data);
            }


            // 
            var expressionConfiguratorBuilder = new ExpressionConfiguratorBuilder();
            var expressionConfigurator = expressionConfiguratorBuilder.Build();
            var filterFactory = new FilterFactory<SomeData>(expressionConfigurator);

            var filter = filterFactory.GetFilter();
            var filteredProperties = filterFactory.GetFilterPropertiesOfType();
            var availableConcatenationOperations = expressionConfigurator.GetAvailableConcatenationOperations();

            while (true)
            {
                var prediction = new Prediction();
                for (int i = 0; i < filteredProperties.Count; i++)
                {
                    Console.WriteLine($"{i}) {filteredProperties[i].PropertyName}");
                }
                Console.Write($"Choose field (index) or -1 to end: ");
                var indexOfProrety = ReadPositiveNumberLessThan(filteredProperties.Count, true);
                if (indexOfProrety == -1)
                {
                    break;
                }

                var filteredProperty = filteredProperties[indexOfProrety];
                prediction.PropertyName = filteredProperty.PropertyName;
                prediction.PropertyType = filteredProperty.PropertyType;

                for (int i = 0; i < availableConcatenationOperations.Count; i++)
                {
                    Console.WriteLine($"{i}) {availableConcatenationOperations[i]}");
                }
                Console.Write("Choose filters concatenation operation (index): ");
                var indexOfConcatenationOperation = ReadPositiveNumberLessThan(availableConcatenationOperations.Count);
                prediction.ConcatenationOperation = availableConcatenationOperations[indexOfConcatenationOperation];

                for (int i = 0; i < filteredProperty.AvailableOperations.Count; i++)
                {
                    Console.WriteLine($"{i}) {filteredProperty.AvailableOperations[i]}");
                }
                Console.Write("Choose operation (index): ");
                var indexOfAction = ReadPositiveNumberLessThan(filteredProperty.AvailableOperations.Count);
                prediction.Operation = filteredProperty.AvailableOperations[indexOfAction];

                if (prediction.Operation.NeedRight)
                {
                    Console.Write("Set right part: ");
                    var rightPart = ReadObj(prediction.PropertyType);
                    prediction.RightValue = rightPart;
                }

                expressionConfigurator.Configure(filter, prediction);
            }

            Console.WriteLine($"lambda: {filter.GetLambda()}");

            var filtered = filter.Filter(someDatas);
            foreach (var round in filtered)
            {
                Console.WriteLine(round);
            }

            Console.Read();
        }

        private static T ReadObj<T>()
        {
            return (T)ReadObj(typeof(T));
        }

        private static object ReadObj(Type type)
        {
            var line = Console.ReadLine();
            object obj = null;

            while (obj == null)
            {
                try
                {
                    obj = Convert.ChangeType(line, type);
                }
                catch (Exception)
                {
                    Console.WriteLine($"'{line}' it is not a {type.Name}. Please enter {type.Name}");
                    line = Console.ReadLine();
                }
            }

            return obj;
        }

        private static int ReadPositiveNumberLessThan(int count, bool isMinusOneAcceptable = false)
        {
            int index = 0;
            while (true)
            {
                index = ReadObj<int>();
                if(index >= 0 && index < count || isMinusOneAcceptable && index == -1) break;
                Console.WriteLine($"The number must be in the range from 0 to {count - 1}");
            }

            return index;
        }
    }
}
