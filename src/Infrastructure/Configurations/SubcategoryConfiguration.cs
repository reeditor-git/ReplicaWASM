using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Infrastructure.Configurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        private readonly Guid _dishesCategoryId = Guid.Parse("b718f35c-6fa7-420b-9acf-82ece06faab9");
        private readonly Guid _drinksCategoryId = Guid.Parse("1f993aaa-9252-4a42-bf4f-b565452dfee7");
        private readonly Guid _hookahsCategoryId = Guid.Parse("3d1f906e-3577-42a2-a1f7-e0b07b209075");
        private readonly Guid _vapeCraftCategoryId = Guid.Parse("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc");
        private readonly Guid _beerLaboratoryCategoryId = Guid.Parse("64306256-7c3f-4de5-a4e1-cda66d426a99");

        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(s => s.Category)
                .WithMany(s => s.Subcategorys)
                .HasForeignKey(s => s.CategoryId);

            builder.HasData(
                new Subcategory
                {
                    Id = Guid.Parse("1ba18109-3b28-4183-894b-6f7741a4074b"),
                    Name = "Перші страви",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("ec23f360-be45-4eec-bb8a-b7c34e0d1c48"),
                    Name = "Гарніри",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("afa905f9-8739-47db-8916-d728d47f8ea2"),
                    Name = "Закуски",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("8487b289-fc03-4bee-9fdd-2ec43be3c1c2"),
                    Name = "Салати",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("db7f2067-9a18-4cc3-b76c-8b4e877b1b3f"),
                    Name = "М'ясо та риба",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("47429c78-1bd8-4da7-9c7b-f6a9a03624df"),
                    Name = "Хліб",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("561be8a7-dac0-4db4-b469-7496adec4fee"),
                    Name = "Соуси",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("ce0cd619-dad3-4121-baff-108183b5ab3e"),
                    Name = "Десерти",
                    Description = "",
                    CategoryId = _dishesCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("12a9a6f2-544c-406f-a7e3-1f2dd87c8ed5"),
                    Name = "Алкогольні",
                    Description = "",
                    CategoryId = _drinksCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("1fd0e67d-72ce-4a4b-9d03-f1c2e8d95521"),
                    Name = "Безалкогольні",
                    Description = "",
                    CategoryId = _drinksCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("c02cba8e-30a1-474b-88e3-19aa9adfc148"),
                    Name = "Табак",
                    Description = "",
                    CategoryId = _hookahsCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("d5de634f-842a-4f3c-a466-47b52d2ae4b2"),
                    Name = "Чаша",
                    Description = "",
                    CategoryId = _hookahsCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("a9fba436-d2f9-408c-af66-d1a381c586d7"),
                    Name = "Рідина",
                    Description = "",
                    CategoryId = _hookahsCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("421c0c78-dee2-4019-8ae9-9eed15927889"),
                    Name = "Одноразки",
                    Description = "",
                    CategoryId = _vapeCraftCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("d67280c0-9c92-449d-8088-cb491b2f4c67"),
                    Name = "Девайси",
                    Description = "",
                    CategoryId = _vapeCraftCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("97935587-4c28-479c-8d74-4e36327f1a04"),
                    Name = "Рідини",
                    Description = "",
                    CategoryId = _vapeCraftCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("82a10754-1207-45f7-bfeb-bf8ad7ac9a99"),
                    Name = "Комплектуючі",
                    Description = "",
                    CategoryId = _vapeCraftCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("473e6b98-2487-4c5f-87c8-a0cee39cd518"),
                    Name = "Пиво",
                    Description = "",
                    CategoryId = _beerLaboratoryCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("8cd585a2-5bc9-460c-b0d2-0bf2216969d4"),
                    Name = "Ель",
                    Description = "",
                    CategoryId = _beerLaboratoryCategoryId
                },
                new Subcategory
                {
                    Id = Guid.Parse("f951e75b-a3e0-4866-bf8e-f341478b2fe7"),
                    Name = "До пива",
                    Description = "",
                    CategoryId = _beerLaboratoryCategoryId
                });
        }
    }
}
