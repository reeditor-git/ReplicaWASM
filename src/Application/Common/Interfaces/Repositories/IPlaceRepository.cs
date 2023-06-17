using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IPlaceRepository
    {
        Task<Guid> CreateAsync(Place place);
        Task DeleteAsync(Guid id);
        Task<Place> GetAsync(Guid id);
        Task<IEnumerable<Place>> GetAllAsync();
        Task UpdateAsync(Place place);
    }
}
