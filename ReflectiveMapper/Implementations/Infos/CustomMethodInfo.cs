using System;
using System.Reflection;
using ReflectiveMapper.Interfaces.Infos;

namespace ReflectiveMapper.Implementations.Infos
{
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
}
