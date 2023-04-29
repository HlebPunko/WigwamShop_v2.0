using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Order.Infostructure.Context
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order.Domain.Entities.Order> Orders { get; set; } = null!;

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
