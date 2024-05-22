﻿namespace ReflectiveMapper.Interfaces.Services
{
    public interface IMapper
    {

        TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : new()
            where TSource : new();


    }
}
