using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface IPaymentStatusRepository
    {
        Task<Guid> CreateAsync(PaymentStatus paymentStatus);
        Task DeleteAsync(Guid id);
        Task<PaymentStatus> GetAsync(Guid id);
        Task<IEnumerable<PaymentStatus>> GetAllAsync();
        Task<bool> UpdateAsync(PaymentStatus paymentStatus);
    }
}
