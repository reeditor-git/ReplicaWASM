using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Category category)
        {
            var newCategory = await _ctx.Categories.AddAsync(category);
            
            await _ctx.SaveChangesAsync();

            return newCategory.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _ctx.Categories.FindAsync(id);

            _ctx.Categories.Remove(category);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Category> GetAsync(Guid id) =>
            await _ctx.Categories.FindAsync(id);

        public async Task<Category> GetByNameAsync(string name) =>
            await _ctx.Categories.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _ctx.Categories.ToListAsync();

        public async Task<bool> UpdateAsync(Category category)
        {
            var updateCategory = await _ctx.Categories.FindAsync(category.Id);

            updateCategory = category;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
