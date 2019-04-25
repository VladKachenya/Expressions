using System;
using System.Collections.Generic;
using FilterLogic.Helpers;

namespace FilterLogic.Interfaces
{
    public interface IExpressionConfigurator
    {
        Dictionary<Guid, IExpressionFormer> Formers { get; }
        void Configure(IFilter predictionExpression, Prediction prediction);
    }
}