using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Infrastructure.Configurations
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
                    Id = Guid.Parse("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                    Name = "Страви",
                    Description = "Страви які пропонує заклад, для своїх відвідувачів."
                },
                new Category 
                {
                    Id = Guid.Parse("1f993aaa-9252-4a42-bf4f-b565452dfee7"),
                    Name = "Напої",
                    Description = "Напої які пропонує заклад, для своїх відвідувачів."
                },
                new Category 
                {
                    Id = Guid.Parse("3d1f906e-3577-42a2-a1f7-e0b07b209075"),
                    Name = "Кальяни",
                    Description = "Компоненти які потрібно обрати, для замовлення кальяну."
                },
                new Category 
                {
                    Id = Guid.Parse("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                    Name = "VapeCraft",
                    Description = "Електронні цигарки, та все необхідне комплектуюче до них."
                },
                new Category
                {
                    Id = Guid.Parse("64306256-7c3f-4de5-a4e1-cda66d426a99"),
                    Name = "BeerLaboratory",
                    Description = "Пивні напої які пропонує заклад, для своїх відвідувачів."
                });
        }
    }
}
