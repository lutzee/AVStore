using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AVStore.WebApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Use Scrutor to find and register implementedInterface, Allows to use a generic interface to register a type using more specific interfaces
        /// </summary>
        /// <param name="services"></param>
        /// <param name="implementedInterface"></param>
        public static void AddClassesImplementingInterface(this IServiceCollection services, Type implementedInterface)
        {
            services.Scan(scan => scan
                .FromAssemblies(implementedInterface.GetTypeInfo().Assembly)
                .AddClasses(classes => classes
                    .Where(x => !x.IsAbstract)
                    .AssignableTo(implementedInterface))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}
