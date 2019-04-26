using ExpressionConsole.Model;
using FilterLogic.Builders;
using FilterLogic.Entities;
using FilterLogic.ExpressionFormers;
using FilterLogic.Heplers;
using System;

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

            var expressionConfigurator = new ExpressionConfigurator();
            expressionConfigurator.AddOrReplaceExpressionFormerForType(typeof(int), new NumberExpressionFormer(typeof(int)));
            expressionConfigurator.AddOrReplaceExpressionFormerForType(typeof(float), new NumberExpressionFormer(typeof(float)));
            expressionConfigurator.AddOrReplaceExpressionFormerForType(typeof(DateTime), new DataTimeExpressionFormer());
            expressionConfigurator.AddOrReplaceExpressionFormerForType(typeof(string), new StringExpressionFormer());
            // Добовляем пользовательский формерователь выражения для типа SomeShape
            expressionConfigurator.AddOrReplaceExpressionFormerForType(typeof(SomeShape), new CustomExpressionFormer());


            var filterFactory = new FilterFactory<SomeData>(expressionConfigurator);
            var filter = filterFactory.GetFilter();
            var filteredProperties = filterFactory.GetFilterProperties();
            var availableConcatenationOperations = expressionConfigurator.GetAvailableConcatenationOperations();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Query: {filter.GetLambda()}");
                for (int i = 0; i < availableConcatenationOperations.Count; i++)
                {
                    Console.WriteLine($"{i}) {availableConcatenationOperations[i]}");
                }
                Console.Write("Choose filters concatenation operation (index) or -1 to do filtring: ");
                var indexOfConcatenationOperation = ReadPositiveNumberLessThan(availableConcatenationOperations.Count, true);
                if (indexOfConcatenationOperation == -1)
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Start pediction configration");
                var prediction = new Prediction();
                prediction.ConcatenationOperation = availableConcatenationOperations[indexOfConcatenationOperation];
                for (int i = 0; i < filteredProperties.Count; i++)
                {
                    Console.WriteLine($"{i}) {filteredProperties[i].PropertyName}");
                }
                Console.Write($"Choose property (index) ");
                var indexOfProrety = ReadPositiveNumberLessThan(filteredProperties.Count);
                var filteredProperty = filteredProperties[indexOfProrety];
                prediction.PropertyName = filteredProperty.PropertyName;
                prediction.PropertyType = filteredProperty.PropertyType;

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
                    var rightPart = ReadObj(prediction.Operation.OperandType);
                    prediction.RightValue = rightPart;
                }

                Console.WriteLine("0) Not invert");
                Console.WriteLine("1) Invert");
                prediction.IsInvers = ReadPositiveNumberLessThan(2) == 1;

                expressionConfigurator.Configure(filter, prediction);
            }

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
                if (index >= 0 && index < count || isMinusOneAcceptable && index == -1)
                {
                    break;
                }

                Console.WriteLine($"The number must be in the range from 0 to {count - 1}");
            }

            return index;
        }
    }
}
