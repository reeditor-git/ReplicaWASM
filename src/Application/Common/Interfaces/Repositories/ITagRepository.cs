using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<Guid> CreateAsync(Tag tag);
        Task DeleteAsync(Guid id);
        Task<Tag> GetAsync(Guid id);
        Task<Tag> GetByNameAsync(string name);
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<bool> UpdateAsync(Tag tag);
    }
}
