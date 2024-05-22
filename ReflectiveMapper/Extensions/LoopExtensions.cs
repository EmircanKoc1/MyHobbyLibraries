using System;
using System.Collections.Generic;

namespace ReflectiveMapper.Extensions
{
    public static class LoopExtensions
    {
        public static void CustomForeach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection) action(item);
        }

    }
}
