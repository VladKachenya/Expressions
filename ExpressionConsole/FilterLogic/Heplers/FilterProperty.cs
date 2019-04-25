using System;
using System.Collections.Generic;
using FilterLogic.Interfaces;

namespace FilterLogic.Heplers
{
    internal class FilterProperty : IFilterProperty
    {
        public string PropertyName { get; }
        public Type PropertyType { get; }
        public List<IOperation> AvailableOperations { get; }

        public FilterProperty(string fieldName, Type fieldType, List<IOperation> availableActions)
        {
            PropertyName = fieldName;
            PropertyType = fieldType;
            AvailableOperations = availableActions;
        }


    }
}