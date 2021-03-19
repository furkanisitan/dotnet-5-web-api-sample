using System;

namespace Shop.WebAPI.Infrastructure.DependencyInjection
{
    static class ServiceLocator
    {
        public static IServiceProvider Instance { get; private set; }

        public static void Configure(IServiceProvider serviceProvider)
        {
            Instance = serviceProvider;
        }

    }
}
