using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IMeasurementUnitRepository
    {
        Task<Guid> CreateAsync(MeasurementUnit measurementUnit);
        Task DeleteAsync(Guid id);
        Task<MeasurementUnit> GetAsync(Guid id);
        Task<IEnumerable<MeasurementUnit>> GetAllAsync();
        Task<bool> UpdateAsync(MeasurementUnit measurementUnit);
    }
}
