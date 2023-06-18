using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class ProductCountRepository 
        : BaseRepository, IProductCountRepository
    {
        public ProductCountRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(ProductCount productCount)
        {
            var newProductCount = await _ctx.ProductCounts
                .AddAsync(productCount);

            await _ctx.SaveChangesAsync();

            return newProductCount.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var productCount = await _ctx.ProductCounts
                .FindAsync(id);

            _ctx.ProductCounts.Remove(productCount);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ProductCount> GetAsync(Guid id) =>
            await _ctx.ProductCounts.FindAsync(id);

        public async Task<IEnumerable<ProductCount>> GetAllAsync() =>
            await _ctx.ProductCounts.ToListAsync();

        public async Task<bool> UpdateAsync(ProductCount productCount)
        {
            var updateProductCount = await _ctx.ProductCounts
                .FindAsync(productCount.Id);

            updateProductCount = productCount;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
