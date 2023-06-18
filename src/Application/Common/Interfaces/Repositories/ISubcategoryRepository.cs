using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ISubcategoryRepository
    {
        Task<Guid> CreateAsync(Subcategory tag);
        Task DeleteAsync(Guid id);
        Task<Subcategory> GetAsync(Guid id);
        Task<Subcategory> GetByNameAsync(string name);
        Task<IEnumerable<Subcategory>> GetAllAsync();
        Task<bool> UpdateAsync(Subcategory tag);
    }
}
