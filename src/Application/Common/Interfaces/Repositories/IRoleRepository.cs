using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetAsync(Guid id);
        Task<IEnumerable<Role>> GetAllAsync();
    }
}
