using DesafioAltudo.Infra.IoC.Features.Containers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesafioAltudo.API.Configurations
{
    public static class DependencyInjectionConfig
    {

        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
