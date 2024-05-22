using ReflectiveMapper.Extensions;
using ReflectiveMapper.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectiveMapper.Implementations.Services
{
    public class Mapper : IMapper
    {
        private readonly ICustomTypeOperation _typeOperation;

        private ICustomTypeOperation ICustomTypeOperation => _typeOperation;

        public Mapper() => _typeOperation = new CustomTypeOperation();

        public TDestination Map<TSource, TDestination>(TSource source)
        where TDestination : new()
        where TSource : new()
        {
            TDestination instance = Activator.CreateInstance<TDestination>();

            IEnumerable<ICustomPropertyInfo> destinationPropertyInfos = ICustomTypeOperation.GetProperties<TDestination>();
            IEnumerable<ICustomPropertyInfo> sourcePropertyInfos = ICustomTypeOperation.GetProperties<TSource>();

            sourcePropertyInfos.CustomForeach(sourcePropertyInfo =>
            {

                destinationPropertyInfos.CustomForeach(destinationPropertyInfo =>
                {

                    if (!sourcePropertyInfo.GetName().Equals(destinationPropertyInfo.GetName()))
                        return;

                    destinationPropertyInfo.SetValue(instance, sourcePropertyInfo.GetValue(source));


                });


            });

            return instance;
        }
    }
    public class CustomTypeOperation : ICustomTypeOperation
    {


        public IEnumerable<ICustomPropertyInfo> GetProperties<TModel>()
        {
            var propertyInfos = GetType<TModel>().GetProperties();
            var propertyInfosLength = propertyInfos.Length;
            int startedIndex = 0;

            ICustomPropertyInfo[] customPropertyInfos = new CustomPropertyInfo[propertyInfosLength];

            propertyInfos.CustomForeach(propertyInfo =>
            {
                customPropertyInfos[startedIndex++] = CustomPropertyInfo.CreatePropertyInfo(propertyInfo);
            });

            return customPropertyInfos;


        }

        public Type GetType<TModel>()
            => typeof(TModel);

        public string GetNameType<TModel>()
            => GetType<TModel>().Name;

        public IEnumerable<ICustomMethodInfo> GetMethods<TModel>()
        {
            MethodInfo[] methodInfos = GetType<TModel>().GetMethods();
            int methodInfosLength = methodInfos.Length;
            int startedIndex = 0;

            ICustomMethodInfo[] customMethodInfos = new CustomMethodInfo[methodInfosLength];

            methodInfos.CustomForeach(methodInfo =>
            {
                customMethodInfos[startedIndex++] = CustomMethodInfo.CreateMethodInfo(methodInfo);
            });

            return customMethodInfos;


        }



    }


    public interface ICustomTypeOperation
    {
        string GetNameType<TModel>();
        IEnumerable<ICustomPropertyInfo> GetProperties<TModel>();
        IEnumerable<ICustomMethodInfo> GetMethods<TModel>();
        Type GetType<TModel>();

    }

    public interface ITypeInfo
    {
        Type Type { get; }
    }

    public interface IMethodInfo
    {
        MethodInfo MethodInfo { get; }
    }

    public interface IPropertyInfo
    {
        PropertyInfo PropertyInfo { get; }
    }

    public interface ICustomMethodInfo : IMethodInfo
    {

        string GetMethodName();
        Type GetMethodReturnType();

    }

    public interface ICustomPropertyInfo : IPropertyInfo
    {
        string GetName();
        Type GetPropertyType();
        bool CanRead();
        bool CanWrite();
        object GetValue(object instance);
        void SetValue(object instance, object value);

    }

    public class CustomMethodInfo : ICustomMethodInfo
    {
        public static CustomMethodInfo CreateMethodInfo(MethodInfo methodInfo) => new CustomMethodInfo(methodInfo);

        private readonly MethodInfo _methodInfo;

        public CustomMethodInfo(MethodInfo methodInfo) => _methodInfo = methodInfo;

        public MethodInfo MethodInfo => _methodInfo;

        public string GetMethodName()
            => _methodInfo.Name;

        public Type GetMethodReturnType()
            => _methodInfo.ReturnType;
    }


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
