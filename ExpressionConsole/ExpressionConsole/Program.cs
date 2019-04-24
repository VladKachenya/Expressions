using ExpressionConsole.Model;
using FilterLogic;
using FilterLogic.Entities;
using FilterLogic.Keys;
using System;

namespace ExpressionConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var expressionFormerFactory = new ExpressionConfiguratorBuilder();
            var expressionFormer = expressionFormerFactory.Build();
            var predictionExpression = new Filter<SomeData>();
            var prediction = new Prediction();

            ///
            prediction.PropertyType = typeof(int);
            prediction.ConcatenationOperation = Operation.Or; 
            prediction.Operation = Operation.Equal;
            prediction.PropertyName = nameof(SomeData.Id);
            prediction.RightValue = 5;

            expressionFormer.Configure(predictionExpression, prediction);

            ///
            prediction.PropertyType = typeof(DateTime);
            prediction.Operation = Operation.Workday;
            prediction.ConcatenationOperation = Operation.And;
            prediction.PropertyName = nameof(SomeData.Birthday);

            expressionFormer.Configure(predictionExpression, prediction);


            Console.WriteLine("Hello World!");
            Console.WriteLine($"lambda: {predictionExpression.GetLambda()}");

            Console.ReadLine();
        }
    }
}
