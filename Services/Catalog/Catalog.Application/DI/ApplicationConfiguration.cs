using Catalog.Application.Services;
using Catalog.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Infostructure.DI
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ApplicationConfigure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICatalogService, CatalogService>();

            return services;
        }
    }
}