using System;

namespace Shop.Business.DependencyResolvers
{
    interface IInstanceFactory
    {
        T GetInstance<T>();

        object GetInstance(Type type);
    }
}
