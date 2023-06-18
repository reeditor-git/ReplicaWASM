using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class PaymentStatusRepository 
        : BaseRepository, IPaymentStatusRepository
    {
        public PaymentStatusRepository(ReplicaDbContext ctx)
            : base(ctx) { }

        public async Task<Guid> CreateAsync(PaymentStatus paymentStatus)
        {
            var newPaymentStatus = await _ctx.PaymentStatuses
                .AddAsync(paymentStatus);

            await _ctx.SaveChangesAsync();

            return newPaymentStatus.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var paymentStatus = await _ctx.PaymentStatuses
                .FindAsync(id);

            _ctx.PaymentStatuses.Remove(paymentStatus);

            await _ctx.SaveChangesAsync();
        }

        public async Task<PaymentStatus> GetAsync(Guid id) =>
            await _ctx.PaymentStatuses.FindAsync(id);

        public async Task<IEnumerable<PaymentStatus>> GetAllAsync() =>
            await _ctx.PaymentStatuses.ToListAsync();

        public async Task<bool> UpdateAsync(PaymentStatus paymentStatus)
        {
            var updatePaymentStatus = await _ctx.PaymentStatuses
                .FindAsync(paymentStatus.Id);

            updatePaymentStatus = paymentStatus;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
