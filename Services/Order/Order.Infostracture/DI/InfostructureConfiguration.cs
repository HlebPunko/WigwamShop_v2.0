using Order.Infostructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infostracture.Repositories;
using Order.Infostracture.Repositories.Interfaces;
using Order.Infostructure;

namespace Order.Infostracture.DI
{
    public static class InfostructureConfiguration
    {
        public static IServiceCollection InfostructureConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var dockerConnect = Environment.GetEnvironmentVariable("DATABASE_URL");

            if(!string.IsNullOrEmpty(dockerConnect))
            {
                services.AddDbContext<OrderDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(dockerConnect);
                });
            }
            else
            {
                services.AddDbContext<OrderDbContext>((DbContextOptionsBuilder options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
                });
            }

            services.AddScoped<IOrderRepository, OrderRepository>();
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
