using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class MeasurementUnitRepository 
        : BaseRepository, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(MeasurementUnit measurementUnit)
        {
            var newMeasurementUnit = await _ctx.MeasurementUnits
                .AddAsync(measurementUnit);

            await _ctx.SaveChangesAsync();

            return newMeasurementUnit.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var measurementUnit = await _ctx.MeasurementUnits
                .FindAsync(id);

            _ctx.MeasurementUnits.Remove(measurementUnit);

            await _ctx.SaveChangesAsync();
        }

        public async Task<MeasurementUnit> GetAsync(Guid id) =>
            await _ctx.MeasurementUnits.FindAsync(id);

        public async Task<IEnumerable<MeasurementUnit>> GetAllAsync() =>
            await _ctx.MeasurementUnits.ToListAsync();

        public async Task<bool> UpdateAsync(MeasurementUnit measurementUnit)
        {
            var updateMeasurementUnit = await _ctx.MeasurementUnits
                .FindAsync(measurementUnit.Id);

            updateMeasurementUnit = measurementUnit;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
