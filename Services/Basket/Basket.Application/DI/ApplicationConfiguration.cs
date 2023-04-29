using Basket.Application.Services;
using Basket.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Infostructure.DI
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ApplicationConfigure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IBasketService, BasketService>();

            return services;
        }
    }
}