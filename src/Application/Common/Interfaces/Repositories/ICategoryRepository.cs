using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Guid> CreateAsync(Category category);
        Task DeleteAsync(Guid id);
        Task<Category> GetAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task UpdateAsync(Category category);
    }
}
