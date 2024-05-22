using System;

namespace ReflectiveMapper.Interfaces.Infos
{
    public interface ICustomMethodInfo : IMethodInfo
    {

        string GetMethodName();
        Type GetMethodReturnType();

    }
}
