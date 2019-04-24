using System;
using System.Collections.Generic;
using FilterLogic.Entities;

namespace FilterLogic.Interfaces
{
    public interface IExpressionConfigurator
    {
        Dictionary<Type, IExpressionFormer> Formers { get; }

        void Configure(IFilter predictionExpression, Prediction prediction);

    }
}