using System;
using System.Collections.Generic;
using FilterLogic.Helpers;
using FilterLogic.Heplers;
using FilterLogic.Keys;

namespace FilterLogic.Interfaces
{
    public interface IExpressionConfigurator
    {
        void Configure(IFilterExpression filterExpression, Prediction prediction);
        void AddOrReplaceExpressionGeneratorForType(Type type, IExpressionGenerator expressionGenerator);
        List<IOperation> GetAvailableOperationsOfType(Type type);
        List<ConcatenationOperation> GetAvailableConcatenationOperations();
    }
}