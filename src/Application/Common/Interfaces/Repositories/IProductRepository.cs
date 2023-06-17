using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Guid> CreateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
    }
}
