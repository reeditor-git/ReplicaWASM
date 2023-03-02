using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Infrastructure.Configurations
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

            builder.Property(u => u.Username)
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
                    Username = "admin",
                    Phone = "0975440309",
                    Email = "admin@gmail.com",
                    Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    RoleId = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("9bbeffef-5cce-40b8-8a40-6dfa637d4800"),
                    FirstName = "Manager",
                    LastName = "Replica",
                    Username = "manager",
                    Phone = "0975440308",
                    Email = "manager@gmail.com",
                    Password = "6ee4a469cd4e91053847f5d3fcb61dbcc91e8f0ef10be7748da4c4a1ba382d17",
                    RoleId = Guid.Parse("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("21f8588e-9af3-4173-9f26-70caf34fa9b7"),
                    FirstName = "Barman",
                    LastName = "Replica",
                    Username = "barman",
                    Phone = "0975440307",
                    Email = "barman@gmail.com",
                    Password = "d7fa96b0923a796d06f7c732d3cc3a8b6579b9e4c921748fd3d93ded5e673aff",
                    RoleId = Guid.Parse("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("3020649d-4974-4331-973b-6d29a02aebb1"),
                    FirstName = "Hookah waiter",
                    LastName = "Replica",
                    Username = "hookahwaiter",
                    Phone = "0975440306",
                    Email = "hookah.waiter@gmail.com",
                    Password = "cb1fa3dcec90d28b039192c8b6f7d9fa8420680f1dc47edf7f93cffacc52c835",
                    RoleId = Guid.Parse("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("f98ee4a4-5378-43a3-9dfc-83d2d46ed2a1"),
                    FirstName = "Waiter",
                    LastName = "Replica",
                    Username = "waiter",
                    Phone = "0975440305",
                    Email = "waiter@gmail.com",
                    Password = "9beb7c0bd91394a08c1138752c0f196ab638f1da2c290184890184cfcb821ab4",
                    RoleId = Guid.Parse("e4821f82-1182-4bf1-a74a-d390d2c040d6"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("6d6e8bd8-9fbc-48f9-8e4d-09bfb943f6a6"),
                    FirstName = "User1",
                    LastName = "Replica",
                    Username = "user1",
                    Phone = "0975440304",
                    Email = "user1@gmail.com",
                    Password = "0a041b9462caa4a31bac3567e0b6e6fd9100787db2ab433d96f6d178cabfce90",
                    RoleId = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                },
                new User
                {
                    Id = Guid.Parse("454de094-4b12-4f93-9cf1-1c3312133dbc"),
                    FirstName = "User2",
                    LastName = "Replica",
                    Username = "user2",
                    Phone = "0975440303",
                    Email = "user2@gmail.com",
                    Password = "6025d18fe48abd45168528f18a82e265dd98d421a7084aa09f61b341703901a3",
                    RoleId = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    ImageUrl = "*/Image/User/default-user-image.jpg"
                });
        }
    }
}
