using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class ReservationRepository
        : BaseRepository, IReservationRepository
    {
        public ReservationRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Reservation reservation)
        {
            var newReservation = await _ctx.Reservations
                .AddAsync(reservation);

            await _ctx.SaveChangesAsync();

            return newReservation.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var reservation = await _ctx.Reservations
                .FindAsync(id);

            _ctx.Reservations.Remove(reservation);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Reservation> GetAsync(Guid id) =>
            await _ctx.Reservations.FindAsync(id);

        public async Task<IEnumerable<Reservation>> GetAllAsync() =>
            await _ctx.Reservations.ToListAsync();

        public async Task<bool> UpdateAsync(Reservation reservation)
        {
            var updateReservation = await _ctx.Reservations
                .FindAsync(reservation.Id);

            updateReservation = reservation;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
