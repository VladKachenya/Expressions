using System;
using System.Collections.Generic;

namespace FilterLogic.Interfaces
{
    public interface IFilterProperty
    {
        string PropertyName { get;}
        Type PropertyType { get;}
        List<IOperation> AvailableOperations { get;}
    }
}