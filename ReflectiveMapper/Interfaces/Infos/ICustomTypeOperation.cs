using System;
using System.Collections.Generic;

namespace ReflectiveMapper.Interfaces.Infos
{
    public interface ICustomTypeOperation
    {
        string GetNameType<TModel>();
        IEnumerable<ICustomPropertyInfo> GetProperties<TModel>();
        IEnumerable<ICustomMethodInfo> GetMethods<TModel>();
        Type GetType<TModel>();

    }
}
