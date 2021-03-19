using Shop.Business.DependencyResolvers.Autofac;
using System;

namespace Shop.Business.DependencyResolvers
{
    public static class InstanceFactory
    {
        private static readonly IInstanceFactory Factory = new AutofacInstanceFactory();

        public static T GetInstance<T>() =>
            Factory.GetInstance<T>();

        public static object GetInstance(Type type) =>
            Factory.GetInstance(type);
    }
}
