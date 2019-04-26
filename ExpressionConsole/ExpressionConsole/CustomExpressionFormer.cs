using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionConsole.Model;
using FilterLogic.ExpressionFormers;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;

namespace ExpressionConsole
{
    public class CustomExpressionFormer : ExpressionFormerBase
    {
        public CustomExpressionFormer()
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
                res.Add(new Operation<string>() { OperationName = operation.ToString(), NeedRight = false });
            }
            res.Add(new Operation<int>( ) {OperationName = "More for Area", NeedRight = true});
            res.Add(new Operation<int>() { OperationName = "Less for Area", NeedRight = true });
            res.Add(new Operation<int>() { OperationName = "More for Perimetr", NeedRight = true });
            res.Add(new Operation<int>() { OperationName = "Less for Perimetr", NeedRight = true });

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