using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Entities;
using FilterLogic.Interfaces;
using FilterLogic.Keys;

namespace FilterLogic.ExpressionFormers
{
    public class DataTimeExpressionFormer : ExpressionFormerBase, IExpressionFormer
    {
        public override void Configure(IFilters predictionExpression, Prediction prediction)
        {
            if (prediction.TypeCode == TypeCode.DateTime)
            {
                var boolExpression =
                    Expression.Property(predictionExpression.ParameterExpression, prediction.PropertyName);

                switch (prediction.FilterAtction)
                {
                    case FilterAtction.Workday:
                        predictionExpression.Predicts.Add(Expression.IsFalse(HolidayExpression(boolExpression)));
                        return;
                    case FilterAtction.Holiday:
                        predictionExpression.Predicts.Add(Expression.IsTrue(HolidayExpression(boolExpression)));
                        return;
                }
            }
            else
            {
                base.Configure(predictionExpression, prediction);
            }
        }

        private Expression HolidayExpression(Expression boolExpression)
        {
            var dayOfWeek = Expression.Property(boolExpression, nameof(DateTime.Now.DayOfWeek));
            var holidayDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var holidayDaysExpression = Expression.Constant(holidayDays);
            return Expression.Call(holidayDaysExpression, holidayDays.GetType().GetMethod("Contains"), dayOfWeek);
        }
    }
}