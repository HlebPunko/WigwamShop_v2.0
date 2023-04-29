using Microsoft.Extensions.DependencyInjection;
using Order.Application.Services;
using Order.Application.Services.Interfaces;
using System.Reflection;

namespace Order.Application.DI
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ApplicationConfigure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}