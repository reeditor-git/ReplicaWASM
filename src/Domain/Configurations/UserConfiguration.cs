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
                    Nickname = "admin",
                    Phone = "0975440309",
                    Email = "admin@gmail.com",
                    Password = "admin",
                    RoleId = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("9bbeffef-5cce-40b8-8a40-6dfa637d4800"),
                    FirstName = "Manager",
                    LastName = "Replica",
                    Nickname = "manager",
                    Phone = "0975440308",
                    Email = "manager@gmail.com",
                    Password = "manager",
                    RoleId = Guid.Parse("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("21f8588e-9af3-4173-9f26-70caf34fa9b7"),
                    FirstName = "Barman",
                    LastName = "Replica",
                    Nickname = "barman",
                    Phone = "0975440307",
                    Email = "barman@gmail.com",
                    Password = "barman",
                    RoleId = Guid.Parse("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("3020649d-4974-4331-973b-6d29a02aebb1"),
                    FirstName = "Hookah waiter",
                    LastName = "Replica",
                    Nickname = "hookah.waiter",
                    Phone = "0975440306",
                    Email = "hookah.waiter@gmail.com",
                    Password = "hookah.waiter",
                    RoleId = Guid.Parse("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("f98ee4a4-5378-43a3-9dfc-83d2d46ed2a1"),
                    FirstName = "Waiter",
                    LastName = "Replica",
                    Nickname = "waiter",
                    Phone = "0975440305",
                    Email = "waiter@gmail.com",
                    Password = "waiter",
                    RoleId = Guid.Parse("e4821f82-1182-4bf1-a74a-d390d2c040d6"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("6d6e8bd8-9fbc-48f9-8e4d-09bfb943f6a6"),
                    FirstName = "User1",
                    LastName = "Replica",
                    Nickname = "user1",
                    Phone = "0975440304",
                    Email = "user1@gmail.com",
                    Password = "user1",
                    RoleId = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("454de094-4b12-4f93-9cf1-1c3312133dbc"),
                    FirstName = "User2",
                    LastName = "Replica",
                    Nickname = "user2",
                    Phone = "0975440303",
                    Email = "user2@gmail.com",
                    Password = "user2",
                    RoleId = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                });
        }
    }
}
