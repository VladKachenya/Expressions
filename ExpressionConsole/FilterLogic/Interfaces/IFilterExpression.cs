using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IFilterExpression
    {
        ParameterExpression ParameterExpression { get; set; }
        BinaryExpression FinalExpression { get; set; }
    }
}