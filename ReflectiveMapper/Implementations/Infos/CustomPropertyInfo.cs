using System;
using System.Reflection;
using ReflectiveMapper.Interfaces.Infos;

namespace ReflectiveMapper.Implementations.Infos
{
    public class CustomPropertyInfo : ICustomPropertyInfo
    {
        public static CustomPropertyInfo CreatePropertyInfo(PropertyInfo propertyInfo) => new CustomPropertyInfo(propertyInfo);


        private readonly PropertyInfo _propertyInfo;

        public CustomPropertyInfo(PropertyInfo propertyInfo) => _propertyInfo = propertyInfo;

        public PropertyInfo PropertyInfo => _propertyInfo;

        public bool CanRead()
            => PropertyInfo.CanRead;

        public bool CanWrite()
            => PropertyInfo.CanWrite;

        public string GetName()
            => PropertyInfo.Name;

        public Type GetPropertyType()
            => PropertyInfo.GetType();

        public object GetValue(object instance)
            => PropertyInfo.GetValue(instance);

        public void SetValue(object instance, object value)
            => PropertyInfo.SetValue(instance, value);
    }
}
