using System;
using System.Collections.Generic;
using System.Reflection;
using FilterLogic.Helpers;
using FilterLogic.Heplers;
using FilterLogic.Interfaces;

namespace FilterLogic.Builders
{
    public class FilterFactory<T>
    {
        private readonly IExpressionConfigurator _expressionConfigurator;

        public FilterFactory(IExpressionConfigurator expressionConfigurator)
        {
            _expressionConfigurator = expressionConfigurator;
        }

        public List<IFilterProperty> GetFilterProperties()
        {
            var type = typeof(T);
            var res = new List<IFilterProperty>();
            var typePropetys = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in typePropetys)
            {
                Type propType = propertyInfo.PropertyType;
                var typeOperations = _expressionConfigurator.GetAvailableOperationsOfType(propType);
                if(typeOperations == null) continue;
                string fropertyName = propertyInfo.Name;
                res.Add(new FilterProperty(fropertyName, propType, typeOperations));
            }
            return res;
        }

        public IDynamicFilter<T> GetFilter()
        {
            return new DynamicFilter<T>();
        }

    }
}