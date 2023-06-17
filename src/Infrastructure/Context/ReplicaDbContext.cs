using Microsoft.EntityFrameworkCore;
using Replica.Domain.Entities;

namespace Replica.Infrastructure.Context
{
    public class ReplicaDbContext : DbContext
    {
        public ReplicaDbContext(DbContextOptions<ReplicaDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceTag> PlaceTags { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(p => p.TotalCost).HasColumnType("decimal(6,2)");

            modelBuilder.Entity<Place>().Property(p => p.RentPrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlaceTag>()
                .HasKey(pt => new
                {
                    pt.PlaceId,
                    pt.TagId
                });

            modelBuilder.Entity<PlaceTag>()
                .HasOne(pt => pt.Place)
                .WithMany(pt => pt.PlaceTags)
                .HasForeignKey(pt => pt.PlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlaceTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PlaceTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new
                {
                    pt.ProductId,
                    pt.TagId
                });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasData(
                new Role
                {
                    Id = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    Name = "admin",
                    Description = "Головний привілейований користувач системи, з усіма рівнями доступу."
                },
                new Role
                {
                    Id = Guid.Parse("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                    Name = "manager",
                    Description = "Керуючий персонал закладу."
                },
                new Role
                {
                    Id = Guid.Parse("8d0bfe93-bd12-44d8-b64c-b18867b4dff2"),
                    Name = "staff",
                    Description = "Персонал лаунж-бару."
                },
                new Role
                {
                    Id = Guid.Parse("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                    Name = "user",
                    Description = "Звичайний користувач системи, клієнт."
                });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReplicaDbContext).Assembly);
        }
    }
}