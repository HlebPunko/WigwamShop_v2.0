using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infostructure.Configurations
{
    internal class WigwamConfiguration : IEntityTypeConfiguration<Wigwam>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wigwam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.WigwamTitle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.WigwamDescription).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
        }
    }
}
