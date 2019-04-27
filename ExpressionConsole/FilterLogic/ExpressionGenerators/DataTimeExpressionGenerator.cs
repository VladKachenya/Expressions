using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.ExpressionGenerators
{
    public class DataTimeExpressionGenerator : ExpressionGeneratorBase
    {
        public DataTimeExpressionGenerator()
        {
            _operations.Add(OperationKeys.Workday, (left, right) => Expression.IsFalse(HolidayExpression(left)));
            _operations.Add(OperationKeys.Holiday, (left, right) => Expression.IsTrue(HolidayExpression(left)));
        }

        public override List<IOperation> GetOperations()
        {
            var res = new List<IOperation>();
            foreach (var operation in _operations)
            {
                res.Add(new Operation(typeof(DateTime)){OperationName = operation.Key});
            }

            return res;
        }

        protected Expression HolidayExpression(Expression boolExpression)
        {
            var dayOfWeek = Expression.Property(boolExpression, nameof(DateTime.Now.DayOfWeek));
            var holidayDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var holidayDaysExpression = Expression.Constant(holidayDays);
            return Expression.Call(holidayDaysExpression, holidayDays.GetType().GetMethod("Contains"), dayOfWeek);
        }
    }
}