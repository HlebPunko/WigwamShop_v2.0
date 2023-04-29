using Basket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Basket.Infostructure.Context
{
    public class BasketDbContext : DbContext
    {
        public DbSet<Wigwam> Wigwams { get; set; } = null!;

        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
