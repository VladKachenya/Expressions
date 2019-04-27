using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FilterLogic.Entities
{
    public class ExpressionConfigurator : IExpressionConfigurator
    {
        private Dictionary<Guid, IExpressionGenerator> _formers { get; } = new Dictionary<Guid, IExpressionGenerator>();

       

        public void Configure(IFilterExpression filterExpression, Prediction prediction)
        {
            var expression = _formers[prediction.PropertyType.GUID].GenerateExpression(filterExpression, prediction);
            if (expression != null)
            {
                if (prediction.IsInvers)
                {
                    expression = Expression.Not(expression);
                }

                switch (prediction.ConcatenationOperation)
                {
                    case ConcatenationOperation.And:
                        filterExpression.FinalExpression =
                            Expression.And(filterExpression.FinalExpression, expression);
                        break;
                    case ConcatenationOperation.Or:
                        filterExpression.FinalExpression =
                            Expression.Or(filterExpression.FinalExpression, expression);
                        break;
                    case ConcatenationOperation.Xor:
                        filterExpression.FinalExpression =
                            Expression.ExclusiveOr(filterExpression.FinalExpression, expression);
                        break;
                }
            }
        }

        public void AddOrReplaceExpressionGeneratorForType(Type type, IExpressionGenerator expressionGenerator)
        {
            if (_formers.ContainsKey(type.GUID))
            {
                _formers.Remove(type.GUID);
            }
            _formers.Add(type.GUID, expressionGenerator);
        }

        public List<IOperation> GetAvailableOperationsOfType(Type type)
        {
            if (_formers.ContainsKey(type.GUID))
            {
                return _formers[type.GUID].GetOperations();
            }
            return null;
        }

        public List<ConcatenationOperation> GetAvailableConcatenationOperations()
        {
            return Enum.GetValues(typeof(ConcatenationOperation)).Cast<ConcatenationOperation>().ToList();
        }
    }
}