using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task BlockUserAsync(Guid id, string reason);
        Task ChangeUserRoleAsync(Guid userId, Guid roleId);
        Task<User> GetUserAsync(Guid id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UnblockUserAsync(Guid id);
    }
}