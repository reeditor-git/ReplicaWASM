using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class PlaceRepository 
        : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Place place)
        {
            var newPlace = await _ctx.Places
                .AddAsync(place);

            await _ctx.SaveChangesAsync();

            return newPlace.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var place = await _ctx.Places
                .FindAsync(id);

            _ctx.Places.Remove(place);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Place> GetAsync(Guid id) =>
            await _ctx.Places.FindAsync(id);

        public async Task<IEnumerable<Place>> GetAllAsync() =>
            await _ctx.Places.ToListAsync();

        public async Task<bool> UpdateAsync(Place place)
        {
            var updatePlace = await _ctx.Places
                .FindAsync(place.Id);

            updatePlace = place;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
