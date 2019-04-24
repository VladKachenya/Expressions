using System.Linq.Expressions;
using FilterLogic.Entities;

namespace FilterLogic.Interfaces
{
    public interface IExpressionFormer
    {
        Expression FormExpression(IFilter predictionExpression, Prediction prediction);
    }
}