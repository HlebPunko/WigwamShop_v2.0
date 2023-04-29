using Microsoft.EntityFrameworkCore;

namespace Order.Infostracture.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order.Domain.Entities.Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order.Domain.Entities.Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.WigwamName).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.WigwamId).IsRequired();
        }
    }
}
