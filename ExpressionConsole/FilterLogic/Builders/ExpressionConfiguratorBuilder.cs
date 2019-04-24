using System;
using System.Collections.Generic;
using System.Linq;
using FilterLogic.ExpressionFormers;
using FilterLogic.Interfaces;

namespace FilterLogic
{
    public class ExpressionConfiguratorBuilder
    {
        public ExpressionConfiguratorBuilder()
        {
        }

        public IExpressionConfigurator Build()
        {
            var result = new ExpressionConfigurator();
            result.Formers.Add(typeof(int), new IntExpressionFormer());
            result.Formers.Add(typeof(DateTime), new DataTimeExpressionFormer());
            return result;
        }
    }
}