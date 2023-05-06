using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Favorite.Infostructure.Configuration
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Domain.Entities.Favorite>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Favorite> builder)
        {
            builder.HasKey(x => x.WigwamId);
            builder.Property(x => x.WigwamId).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
        }
    }
}
