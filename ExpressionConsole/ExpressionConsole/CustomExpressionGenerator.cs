using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionConsole.Model;
using FilterLogic.ExpressionGenerators;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;

namespace ExpressionConsole
{
    public class CustomExpressionGenerator : ExpressionGeneratorBase
    {
        public CustomExpressionGenerator()
        {
            var shapes = Enum.GetValues(typeof(Shapes)).Cast<Shapes>().ToList();
            foreach (var shapese in shapes)
            {
                _operations.Add(shapese.ToString(), (left, right) => GetExpressionForName(left, shapese.ToString()));
            }

            _operations.Add("More for Area", (left, right) => Expression.GreaterThan(Expression.Property(left, nameof(SomeShape.Area)), right));
            _operations.Add("Less for Area", (left, right) => Expression.LessThan(Expression.Property(left, nameof(SomeShape.Area)), right));
            _operations.Add("More for Perimetr", (left, right) => Expression.GreaterThan(Expression.Property(left, nameof(SomeShape.Perimetr)), right));
            _operations.Add("Less for Perimetr", (left, right) => Expression.GreaterThan(Expression.Property(left, nameof(SomeShape.Perimetr)), right));

        }

        public override List<IOperation> GetOperations()
        {
            var res = new List<IOperation>();
            foreach (var operation in Enum.GetValues(typeof(Shapes)))
            {
                res.Add(new Operation(typeof(string)) { OperationName = operation.ToString(), NeedRight = false });
            }

            var intType = typeof(int);
            res.Add(new Operation(intType) {OperationName = "More for Area", NeedRight = true});
            res.Add(new Operation(intType) { OperationName = "Less for Area", NeedRight = true });
            res.Add(new Operation(intType) { OperationName = "More for Perimetr", NeedRight = true });
            res.Add(new Operation(intType) { OperationName = "Less for Perimetr", NeedRight = true });

            return res;
        }

        private Expression GetExpressionForName(Expression left, string shape)
        {
            var con = Expression.Constant(shape);
            var prop = Expression.Property(left, nameof(SomeShape.Name));
            var shapeName = Expression.Call(prop, typeof(Enum).GetMethod("ToString", Type.EmptyTypes));
            return Expression.Equal(shapeName, con);
        }
    }
}