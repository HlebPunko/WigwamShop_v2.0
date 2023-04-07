using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Infostructure.Context
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Wigwam> Wigwams { get; set; } = null!;

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
