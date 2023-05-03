using Basket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infostructure.Configurations
{
    internal class WigwamConfiguration : IEntityTypeConfiguration<Wigwam>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wigwam> builder)
        {
            builder.HasKey(x => x.WigwamId);
            builder.Property(x => x.WigwamId).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
        }
    }
}
