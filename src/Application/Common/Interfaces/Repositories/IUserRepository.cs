using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> CreateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
    }
}
