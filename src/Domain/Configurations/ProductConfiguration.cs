using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasDefaultValue("*/Image/User/default-product-image.jpg");

            builder.Property(p => p.Size)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.MeasurementUnits)
                .IsRequired()
                .HasDefaultValue(Enum.MeasurementUnits.кг);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(6,2)")
                .HasDefaultValue(0);

            builder.HasOne(p => p.Subcategory)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.SubcategoryId);

            builder.HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Сирний крем-суп",
                    Description = "",
                    ImageUrl = "*/Image/User/default-product-image.jpg",
                    Size = 300,
                    MeasurementUnits = Enum.MeasurementUnits.г,
                    Price = 75M,
                    SubcategoryId = Guid.Parse("1ba18109-3b28-4183-894b-6f7741a4074b"),
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Борщ з телятиною",
                    Description = "",
                    ImageUrl = "*/Image/User/default-product-image.jpg",
                    Size = 350,
                    MeasurementUnits = Enum.MeasurementUnits.г,
                    Price = 87M,
                    SubcategoryId = Guid.Parse("1ba18109-3b28-4183-894b-6f7741a4074b"),
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Пельмені домашні",
                    Description = "",
                    ImageUrl = "*/Image/User/default-product-image.jpg",
                    Size = 220,
                    MeasurementUnits = Enum.MeasurementUnits.г,
                    Price = 75M,
                    SubcategoryId = Guid.Parse("afa905f9-8739-47db-8916-d728d47f8ea2"),
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Кабачкові рулети з вершковим сиром",
                    Description = "",
                    ImageUrl = "*/Image/User/default-product-image.jpg",
                    Size = 180,
                    MeasurementUnits = Enum.MeasurementUnits.г,
                    Price = 83M,
                    SubcategoryId = Guid.Parse("afa905f9-8739-47db-8916-d728d47f8ea2"),
                });
        }
    }
}
