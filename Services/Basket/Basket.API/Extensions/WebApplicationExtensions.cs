using Basket.Infostructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public async static Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var contextCatalog = scope.ServiceProvider.GetRequiredService<BasketDbContext>();

                await contextCatalog!.Database.MigrateAsync();
            }

            return app;
        }
    }
}
