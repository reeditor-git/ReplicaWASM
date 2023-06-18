using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Guid> CreateAsync(Reservation reservation);
        Task DeleteAsync(Guid id);
        Task<Reservation> GetAsync(Guid id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<bool> UpdateAsync(Reservation reservation);
    }
}
