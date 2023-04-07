using Catalog.Infostructure.Context;
using Catalog.Infostructure.Repositories;
using Catalog.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infostructure.DI
{
    public static class InfostructureConfiguration
    {
        public static IServiceCollection InfostructureConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>((DbContextOptionsBuilder options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });

            services.AddScoped<ICatalogRepository, CatalogRepository>();

            return services;
        }
    }
}
