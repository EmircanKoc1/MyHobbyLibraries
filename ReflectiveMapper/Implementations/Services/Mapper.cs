using ReflectiveMapper.Extensions;
using ReflectiveMapper.Implementations.Operations;
using ReflectiveMapper.Interfaces.Infos;
using ReflectiveMapper.Interfaces.Services;
using System;
using System.Collections.Generic;

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
}
