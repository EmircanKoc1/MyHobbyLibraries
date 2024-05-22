using System;

namespace ReflectiveMapper.Interfaces.Infos
{
    public interface ICustomPropertyInfo : IPropertyInfo
    {
        string GetName();
        Type GetPropertyType();
        bool CanRead();
        bool CanWrite();
        object GetValue(object instance);
        void SetValue(object instance, object value);

    }
}
