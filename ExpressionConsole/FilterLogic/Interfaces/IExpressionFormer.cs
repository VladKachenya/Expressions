using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Helpers;
using FilterLogic.Heplers;

namespace FilterLogic.Interfaces
{
    public interface IExpressionFormer
    {
        Expression FormExpression(IFilter predictionExpression, Prediction prediction);
        List<Operation> GetOperations();
    }
}