using Favorite.Application.Services;
using Favorite.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Favorite.Application.DI
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ApplicationConfigure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IFavoriteService, FavoriteService>();

            return services;
        }
    }
}
