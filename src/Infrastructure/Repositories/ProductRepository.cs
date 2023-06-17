using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Product product)
        {
            var newProduct = await _ctx.Products.AddAsync(product);

            await _ctx.SaveChangesAsync();

            return newProduct.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _ctx.Products.FindAsync(id);

            _ctx.Products.Remove(product);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Product> GetAsync(Guid id) =>
            await _ctx.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _ctx.Products.ToListAsync();

        public async Task UpdateAsync(Product product)
        {
            var updateProduct = await _ctx.Products.FindAsync(product.Id);

            updateProduct = product;

            await _ctx.SaveChangesAsync();
        }
    }
}
