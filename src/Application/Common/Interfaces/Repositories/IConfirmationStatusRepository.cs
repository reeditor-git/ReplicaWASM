using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IConfirmationStatusRepository
    {
        Task<Guid> CreateAsync(ConfirmationStatus confirmationStatus);
        Task DeleteAsync(Guid id);
        Task<ConfirmationStatus> GetAsync(Guid id);
        Task<ConfirmationStatus> GetByNameAsync(string name);
        Task<IEnumerable<ConfirmationStatus>> GetAllAsync();
        Task<bool> UpdateAsync(ConfirmationStatus confirmationStatus);
    }
}
