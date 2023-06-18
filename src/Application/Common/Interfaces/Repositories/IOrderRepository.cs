using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> CreateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task<Order> GetAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<bool> UpdateAsync(Order order);
    }
}
