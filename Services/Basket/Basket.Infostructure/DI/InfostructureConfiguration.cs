using Basket.Infostructure.Context;
using Basket.Infostructure.Repositories;
using Basket.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Basket.Infostructure.DI
{
    public static class InfostructureConfiguration
    {
        public static IServiceCollection InfostructureConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var dockerConnect = Environment.GetEnvironmentVariable("DATABASE_URL");

            if(!string.IsNullOrEmpty(dockerConnect))
            {
                services.AddDbContext<BasketDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(dockerConnect);
                });
            }
            else
            {
                services.AddDbContext<BasketDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
                });
            }

            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }
    }
}
