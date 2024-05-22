using System;

namespace ReflectiveMapper.Interfaces.Infos
{
    public interface ICustomPropertyInfo : IPropertyInfo
    {
        string GetName();
        Type GetPropertyType();
        string GetPropertyTypeName();
        bool CanRead();
        bool CanWrite();
        object? GetValue(object instance);
        void SetValue(object instance, object value);

    }
}
