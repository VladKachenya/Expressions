using System;
using FilterLogic;
using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using FilterLogic.Model;

namespace ExpressionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressionFormerFactory = new ExpressionFormerBuilder();
            var expressionFormer = expressionFormerFactory.GetExpressionFormer();
            var predictionExpression = new PredictionExpression<SomeData>(); 
            var prediction = new Prediction();

            ///
            prediction.TypeCode = TypeCode.Int32;
            prediction.FilterAtction = FilterAtction.Equal;
            prediction.PropertyName = nameof(SomeData.Id);
            prediction.RightValue = 5;

            expressionFormer.Configure(predictionExpression, prediction);

            ///
            prediction.TypeCode = TypeCode.DateTime;
            prediction.FilterAtction = FilterAtction.Workday;
            prediction.PropertyName = nameof(SomeData.Birthday);

            expressionFormer.Configure(predictionExpression, prediction);


            Console.WriteLine("Hello World!");
            Console.WriteLine($"lambda: {predictionExpression.GetLambda()}");

            Console.ReadLine();
        }
    }
}
