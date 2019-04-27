using System.Collections.Generic;
using System.Linq.Expressions;
using FilterLogic.Helpers;
using FilterLogic.Heplers;

namespace FilterLogic.Interfaces
{
    public interface IExpressionGenerator
    {
        Expression GenerateExpression(IFilterExpression filterExpression, Prediction prediction);
        List<IOperation> GetOperations();
    }
}