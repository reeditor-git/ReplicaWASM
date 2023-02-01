using Microsoft.EntityFrameworkCore;
using Replica.Domain.Entities;

namespace Replica.Domain
{
    public class ReplicaDbContext : DbContext
    {
        public ReplicaDbContext(DbContextOptions<ReplicaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(p => p.TotalCost).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<ProductSize>().Property(p => p.Price).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<Place>().Property(p => p.RentPrice).HasColumnType("decimal(6,2)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReplicaDbContext).Assembly);
        }
    }
}