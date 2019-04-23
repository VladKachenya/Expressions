using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.Interfaces
{
    public interface IFilters
    {
        ParameterExpression ParameterExpression { get; set; }
        List<Expression> Predicts { get; }
    }
}