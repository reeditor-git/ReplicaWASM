using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ISubcategoryRepository
    {
        Task<Guid> CreateAsync(Subcategory tag);
        Task DeleteAsync(Guid id);
        Task<Subcategory> GetAsync(Guid id);
        Task<IEnumerable<Subcategory>> GetAllAsync();
        Task UpdateAsync(Subcategory tag);
    }
}
