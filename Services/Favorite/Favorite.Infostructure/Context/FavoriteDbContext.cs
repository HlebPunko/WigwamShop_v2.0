using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Favorite.Infostructure.Context
{
    public class FavoriteDbContext : DbContext
    {
        public DbSet<Domain.Entities.Favorite> favorite { get; set; }

        public FavoriteDbContext(DbContextOptions<FavoriteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
