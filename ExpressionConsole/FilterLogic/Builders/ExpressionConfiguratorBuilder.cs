using System;
using System.Collections.Generic;
using System.Linq;
using FilterLogic.Entities;
using FilterLogic.ExpressionFormers;
using FilterLogic.Interfaces;

namespace FilterLogic
{
    public class ExpressionConfiguratorBuilder
    {

        public IExpressionConfigurator Build()
        {
            var result = new ExpressionConfigurator();
            result.AddOrReplaceExpressionFormerForType(typeof(int), new IntExpressionFormer());
            result.AddOrReplaceExpressionFormerForType(typeof(DateTime), new DataTimeExpressionFormer());
            return result;
        }
    }
}