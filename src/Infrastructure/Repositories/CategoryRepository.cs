using Microsoft.EntityFrameworkCore;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly ReplicaDbContext _context;

        public CategoryRepository(ReplicaDbContext context) =>
            _context = context;

        public async Task AddCategoryAsync (Category category)
        {
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await _context.Categories.ToListAsync();

    }
}
