using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class ConfirmationStatusRepository 
        : BaseRepository, IConfirmationStatusRepository
    {
        public ConfirmationStatusRepository(ReplicaDbContext ctx)
            : base(ctx) { }

        public async Task<Guid> CreateAsync(ConfirmationStatus confirmationStatus)
        {
            var newConfirmationStatus = await _ctx.ConfirmationStatuses
                .AddAsync(confirmationStatus);

            await _ctx.SaveChangesAsync();

            return newConfirmationStatus.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var confirmationStatus = await _ctx.ConfirmationStatuses
                .FindAsync(id);

            _ctx.ConfirmationStatuses.Remove(confirmationStatus);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ConfirmationStatus> GetAsync(Guid id) =>
            await _ctx.ConfirmationStatuses.FindAsync(id);

        public async Task<ConfirmationStatus> GetByNameAsync(string name) =>
            await _ctx.ConfirmationStatuses.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<ConfirmationStatus>> GetAllAsync() =>
            await _ctx.ConfirmationStatuses.ToListAsync();

        public async Task<bool> UpdateAsync(ConfirmationStatus confirmationStatus)
        {
            var updateConfirmationStatus = await _ctx.ConfirmationStatuses
                .FindAsync(confirmationStatus.Id);

            updateConfirmationStatus = confirmationStatus;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
