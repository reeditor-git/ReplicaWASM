using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(t => t.Products)
                .WithMany(t => t.Tags);

            builder.HasData(
                new Tag
                {
                    Id = Guid.Parse("2ac51f75-6248-4c4f-898d-19d32e23ff26"),
                    Name = "Сир"
                },
                new Tag
                {
                    Id = Guid.Parse("feaab256-c7db-4cf0-95e9-6cc764da4f60"),
                    Name = "Курятина"
                },
                new Tag
                {
                    Id = Guid.Parse("9df3190c-9ce0-479e-89a8-9b5b0ad9fa01"),
                    Name = "Телятина"
                },
                new Tag
                {
                    Id = Guid.Parse("ea0b7d5f-1a08-49bd-a229-c3e60bc45d3c"),
                    Name = "Борщ"
                },
                new Tag
                {
                    Id = Guid.Parse("9b3021be-d034-45b6-a206-7c2c241e983e"),
                    Name = "Кабачки"
                },
                new Tag
                {
                    Id = Guid.Parse("d83fbb8c-adbe-47e0-b96d-574a8da5f35f"),
                    Name = "Домашнє"
                },
                new Tag
                {
                    Id = Guid.Parse("96a405fe-8b33-4396-bf4e-c38fb888aef6"),
                    Name = "М'ясо"
                },
                new Tag
                {
                    Id = Guid.Parse("e312485e-9217-4cd7-9e3f-8c3d47d44a0c"),
                    Name = "Катопля"
                }, 
                new Tag
                {
                    Id = Guid.Parse("cfc264d7-4da6-433a-a6d0-fd7d86f88029"),
                    Name = "Вершки"
                });
        }
    }
}
