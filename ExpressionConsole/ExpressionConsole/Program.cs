using ExpressionConsole.Model;
using FilterLogic;
using FilterLogic.Helpers;
using FilterLogic.Keys;
using System;
using FilterLogic.Heplers;

namespace ExpressionConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var expressionConfiguratorBuilder = new ExpressionConfiguratorBuilder();
            var expressionConfigurator = expressionConfiguratorBuilder.Build();
            var predictionExpression = new Filter<SomeData>();
            var prediction = new Prediction();

            ///
            prediction.PropertyType = typeof(int);
            prediction.ConcatenationOperation = ConcatenationOperation.Or;
            prediction.Operation = expressionConfigurator.Formers[typeof(int).GUID].GetOperations()[0];
            prediction.PropertyName = nameof(SomeData.Id);
            prediction.RightValue = 5;

            expressionConfigurator.Configure(predictionExpression, prediction);

            ///
            prediction.PropertyType = typeof(DateTime);
            prediction.Operation = new Operation() {OperationName = "Holiday" };
            prediction.ConcatenationOperation = ConcatenationOperation.And;
            prediction.PropertyName = nameof(SomeData.Birthday);
            expressionConfigurator.Configure(predictionExpression, prediction);


            Console.WriteLine("Hello World!");
            Console.WriteLine($"lambda: {predictionExpression.GetLambda()}");

            Console.ReadLine();
        }
    }
}
