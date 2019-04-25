using FilterLogic.Heplers;
using FilterLogic.Interfaces;
using FilterLogic.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FilterLogic.Entities
{
    internal class ExpressionConfigurator : IExpressionConfigurator
    {
        private Dictionary<Guid, IExpressionFormer> _formers { get; } = new Dictionary<Guid, IExpressionFormer>();

       

        public void Configure(IPredictionExpression predictionExpression, Prediction prediction)
        {
            var expression = _formers[prediction.PropertyType.GUID].FormExpression(predictionExpression, prediction);
            if (expression != null)
            {
                switch (prediction.ConcatenationOperation)
                {
                    case ConcatenationOperation.And:
                        predictionExpression.FinalExpression =
                            Expression.And(predictionExpression.FinalExpression, expression);
                        break;
                    case ConcatenationOperation.Or:
                        predictionExpression.FinalExpression =
                            Expression.Or(predictionExpression.FinalExpression, expression);
                        break;
                }
            }
        }

        public void AddOrReplaceExpressionFormerForType(Type type, IExpressionFormer expressionFormer)
        {
            if (_formers.ContainsKey(type.GUID))
            {
                _formers.Remove(type.GUID);
            }
            _formers.Add(type.GUID, expressionFormer);
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