using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IPredictionExpression
    {
        ParameterExpression ParameterExpression { get; set; }
        BinaryExpression FinalExpression { get; set; }
    }
}