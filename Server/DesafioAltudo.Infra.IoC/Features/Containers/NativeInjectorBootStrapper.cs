
using BaseProject.Infra.ORM.Context;
using DesafioAltudo.Application.Features.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioAltudo.Infra.IoC.Features.Containers
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IPageService, PageService>();
        }

    }
}
