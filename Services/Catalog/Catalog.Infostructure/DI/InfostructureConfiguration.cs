using Catalog.Infostructure.Context;
using Catalog.Infostructure.Repositories;
using Catalog.Infostructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

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
            services.AddScoped<DataSeeder>();

            return services;
        }

        public async static Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var service = serviceScope.ServiceProvider.GetService<DataSeeder>();

                await service!.InitializeDBAsync();
            }

            return app;
        }
    }
}
