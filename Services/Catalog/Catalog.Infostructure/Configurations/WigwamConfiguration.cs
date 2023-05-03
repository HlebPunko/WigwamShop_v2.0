using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infostructure.Configurations
{
    internal class WigwamConfiguration : IEntityTypeConfiguration<Wigwam>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wigwam> builder)
        {
            builder.HasKey(x => x.WigwamId);
            builder.Property(x => x.WigwamId).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
        }
    }
}
