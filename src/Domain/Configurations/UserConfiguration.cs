using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(u => u.Nickname)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(u => u.Birthday)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(u => u.ImageUrl)
                .IsRequired()
                .HasDefaultValue("*/Image/User/default-user-image.jpg");

            builder.HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId);

            builder.HasData(
                new User
                {
                    Id = Guid.Parse("d4e6d597-950b-4d87-b568-9ce087f3c79f"),
                    FirstName = "Admin",
                    LastName = "Replica",
                    Nickname = "Reeditor",
                    Phone = "0975440309",
                    Email = "admin@replica.com",
                    Password = "admin",
                    RoleId = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                });
        }
    }
}
