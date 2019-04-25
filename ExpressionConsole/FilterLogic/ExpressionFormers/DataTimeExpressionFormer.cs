using FilterLogic.Helpers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilterLogic.Heplers;

namespace FilterLogic.ExpressionFormers
{
    public class DataTimeExpressionFormer : ExpressionFormerBase, IExpressionFormer
    {
        public DataTimeExpressionFormer()
        {
            _operations.Add(OperationKeys.WorkdayKey, expression => Expression.IsFalse(HolidayExpression(expression[0])));
            _operations.Add(OperationKeys.HolidayKey, expression => Expression.IsTrue(HolidayExpression(expression[0])));
        }

        public Expression FormExpression(IFilter predictionExpression, Prediction prediction)
        {
            var boolExpression =
                Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);
            return _operations[prediction.Operation.OperationName].Invoke(new []{boolExpression});
        }

        public List<Operation> GetOperations()
        {
            var res = new List<Operation>();
            foreach (var operation in _operations)
            {
                res.Add(new Operation(){OperationName = operation.Key});
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