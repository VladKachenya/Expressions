using System;
using System.Collections.Generic;
using FilterLogic.Helpers;
using FilterLogic.Heplers;
using FilterLogic.Keys;

namespace FilterLogic.Interfaces
{
    public interface IExpressionConfigurator
    {
        void Configure(IPredictionExpression predictionExpression, Prediction prediction);
        void AddOrReplaceExpressionFormerForType(Type type, IExpressionFormer expressionFormer);
        List<IOperation> GetAvailableOperationsOfType(Type type);
        List<ConcatenationOperation> GetAvailableConcatenationOperations();
    }
}