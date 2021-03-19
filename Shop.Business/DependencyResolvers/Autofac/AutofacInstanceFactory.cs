using Autofac;
using System;

namespace Shop.Business.DependencyResolvers.Autofac
{
    class AutofacInstanceFactory : IInstanceFactory
    {
        private static volatile IContainer _container;
        private static readonly object LockObj = new();

        private static IContainer Container
        {
            get
            {
                if (_container != null) return _container;
                lock (LockObj)
                {
                    if (_container != null) return _container;
                    var builder = new ContainerBuilder();
                    builder.RegisterModule(new AutofacBusinessModule());
                    _container = builder.Build();
                }
                return _container;
            }
        }

        public T GetInstance<T>() =>
             Container.Resolve<T>();

        public object GetInstance(Type type) =>
             Container.Resolve(type);
    }
}
