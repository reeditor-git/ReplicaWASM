using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Domain.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasMany(r => r.Users)
                .WithOne(r => r.Role);

            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    Name = "admin",
                    Description = "The main user of the system, with all access rights."
                },
                new Role
                {
                    Id = Guid.Parse("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                    Name = "manager",
                    Description = "The management staff of the lounge bar."
                },
                new Role
                {
                    Id = Guid.Parse("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"),
                    Name = "barman",
                    Description = "Responsible for the bar."
                },
                new Role
                {
                    Id = Guid.Parse("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"),
                    Name = "hookah-waiter",
                    Description = "Responsible for preparing hookah orders."
                },
                new Role
                {
                    Id = Guid.Parse("e4821f82-1182-4bf1-a74a-d390d2c040d6"),
                    Name = "waiter",
                    Description = "Staff who form orders and serve meals to visitors."
                },
                new Role
                {
                    Id = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    Name = "user",
                    Description = "An ordinary user of the system, a client."
                }
                );
        }
    }
}
