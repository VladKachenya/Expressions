using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public class DataTimeExpressionFormer : IExpressionFormer
    {
        public Expression FormExpression(IFilter predictionExpression, Prediction prediction)
        {
            var boolExpression =
                Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);

            switch (prediction.Operation)
            {
                case Operation.Workday:
                    return Expression.IsFalse(HolidayExpression(boolExpression));
                case Operation.Holiday:
                    return Expression.IsTrue(HolidayExpression(boolExpression));
            }
            return null;
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