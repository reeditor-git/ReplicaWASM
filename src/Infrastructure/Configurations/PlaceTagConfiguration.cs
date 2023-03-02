using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Infrastructure.Configurations
{
    public class PlaceTagConfiguration : IEntityTypeConfiguration<PlaceTag>
    {
        public void Configure(EntityTypeBuilder<PlaceTag> builder)
        {
            builder.HasKey(pt => new
            {
                pt.PlaceId,
                pt.TagId
            });

            builder.HasOne(pt => pt.Place)
                .WithMany(pt => pt.PlaceTags)
                .HasForeignKey(pt => pt.PlaceId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PlaceTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
