using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<Guid> CreateAsync(Comment comment);
        Task DeleteAsync(Guid id);
        Task<Comment> GetAsync(Guid id);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<bool> UpdateAsync(Comment comment);
    }
}
