using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.HasKey(pt => new
            {
                pt.ProductId,
                pt.TagId
            });

            builder.HasOne(pt => pt.Product)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
