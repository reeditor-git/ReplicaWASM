using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IProductCountRepository
    {
        Task<Guid> CreateAsync(ProductCount productCount);
        Task DeleteAsync(Guid id);
        Task<ProductCount> GetAsync(Guid id);
        Task<IEnumerable<ProductCount>> GetAllAsync();
        Task<bool> UpdateAsync(ProductCount productCount);
    }
}
