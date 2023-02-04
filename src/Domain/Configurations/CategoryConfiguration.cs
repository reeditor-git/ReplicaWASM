using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.Font)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValue("Calibri");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasData(
                new Category
                {
                    Name = "Страви",
                    Description = "Страви які пропонує заклад, для своїх відвідувачів."
                },
                new Category 
                {
                    Name = "Напої",
                    Description = "Напої які пропонує заклад, для своїх відвідувачів."
                },
                new Category 
                {
                    Name = "Кальяни",
                    Description = "Компоненти які потрібно обрати, для замовлення кальяну."
                },
                new Category 
                {
                    Name = "VapeCraft",
                    Description = "Електронні цигарки, та все необхідне комплектуюче до них."
                },
                new Category
                {
                    Name = "BeerLaboratory",
                    Description = "Пивні напої які пропонує заклад, для своїх відвідувачів."
                });
        }
    }
}
