using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;
using Replica.Domain.Enums;

namespace Replica.Infrastructure.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasDefaultValue("*/Image/User/default-place-image.jpg");

            builder.Property(p => p.SeatingCapacity)
                .IsRequired()
                .HasDefaultValue(2);

            builder.Property(p => p.RentPrice)
                .IsRequired()
                .HasColumnType("decimal(6,2)")
                .HasDefaultValue(0);

            builder.Property(p => p.Available)
                .HasDefaultValue(PlaceAvailable.Вільно);

            builder.HasData(
                new Place
                {
                    Id = Guid.NewGuid(),
                    Name = "Стіл 1",
                    Description = "",
                    ImageUrl = "*/Image/User/default-place-image.jpg",
                    SeatingCapacity = 2,
                    RentPrice = 0,
                    Available = PlaceAvailable.Вільно
                },
                new Place
                {
                    Id = Guid.NewGuid(),
                    Name = "Ігрова зона з PS5",
                    Description = "",
                    ImageUrl = "*/Image/User/default-place-image.jpg",
                    SeatingCapacity = 6,
                    RentPrice = 400,
                    Available = PlaceAvailable.Вільно
                },
                new Place
                {
                    Id = Guid.NewGuid(),
                    Name = "Ігрова зона з XBox",
                    Description = "",
                    ImageUrl = "*/Image/User/default-place-image.jpg",
                    SeatingCapacity = 4,
                    RentPrice = 300,
                    Available = PlaceAvailable.Вільно
                },
                new Place
                {
                    Id = Guid.NewGuid(),
                    Name = "Стіл 2",
                    Description = "",
                    ImageUrl = "*/Image/User/default-place-image.jpg",
                    SeatingCapacity = 4,
                    RentPrice = 0,
                    Available = PlaceAvailable.Вільно
                },
                new Place
                {
                    Id = Guid.NewGuid(),
                    Name = "Стіл 3",
                    Description = "",
                    ImageUrl = "*/Image/User/default-place-image.jpg",
                    SeatingCapacity = 4,
                    RentPrice = 0,
                    Available = PlaceAvailable.Вільно
                });
        }
    }
}
