using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Order order)
        {
            var newOrder = await _ctx.Orders.AddAsync(order);

            await _ctx.SaveChangesAsync();

            return newOrder.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _ctx.Orders.FindAsync(id);

            _ctx.Orders.Remove(order);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Order> GetAsync(Guid id) =>
            await _ctx.Orders.FindAsync(id);

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _ctx.Orders.ToListAsync();

        public async Task<bool> UpdateAsync(Order order)
        {
            var updateOrder = await _ctx.Orders.FindAsync(order.Id);

            updateOrder = order;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
