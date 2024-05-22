using ReflectiveMapper.Extensions;
using ReflectiveMapper.Implementations.Infos;
using ReflectiveMapper.Interfaces.Infos;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectiveMapper.Implementations.Operations
{
    public class CustomTypeOperation : ICustomTypeOperation
    {

        public static CustomTypeOperation CreateTypeOperation() => new CustomTypeOperation();
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

        private Type GetType<TModel>()
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
}
