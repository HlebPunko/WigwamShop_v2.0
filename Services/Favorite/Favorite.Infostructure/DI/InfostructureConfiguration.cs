using Favorite.Infostructure.Context;
using Favorite.Infostructure.Repositories;
using Favorite.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Favorite.Infostructure.DI
{
    public static class InfostructureConfiguration
    {
        public static IServiceCollection InfostructureConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var dockerConnect = Environment.GetEnvironmentVariable("DATABASE_URL");

            if(!string.IsNullOrEmpty(dockerConnect))
            {
                services.AddDbContext<FavoriteDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(dockerConnect);
                });
            }
            else
            {
                services.AddDbContext<FavoriteDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
                });
            }

            services.AddScoped<IFavoriteRepository, FavoriteRepository>();

            return services;
        }
    }
}
