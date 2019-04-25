using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterLogic.ExpressionFormers
{
    public class ExpressionFormerBase
    {
        protected Dictionary<string, Func<Expression[], Expression>> _operations = new Dictionary<string, Func<Expression[], Expression>>();
    }
}