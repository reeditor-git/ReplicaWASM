using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class SubcategoryRepository : BaseRepository, ISubcategoryRepository
    {
        public SubcategoryRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Subcategory subcategory)
        {
            var newSubcategory = await _ctx.Subcategories.AddAsync(subcategory);

            await _ctx.SaveChangesAsync();

            return newSubcategory.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var subcategory = await _ctx.Subcategories.FindAsync(id);
            _ctx.Subcategories.Remove(subcategory);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Subcategory> GetAsync(Guid id) =>
            await _ctx.Subcategories.FindAsync(id);

        public async Task<Subcategory> GetByNameAsync(string name) =>
            await _ctx.Subcategories.FirstOrDefaultAsync(x => x.Name ==  name);

        public async Task<IEnumerable<Subcategory>> GetAllAsync() =>
            await _ctx.Subcategories.ToListAsync();

        public async Task<bool> UpdateAsync(Subcategory subcategory)
        {
            var updateSubcategory = await _ctx.Subcategories.FindAsync(subcategory.Id);

            updateSubcategory = subcategory;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
