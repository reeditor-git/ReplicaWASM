using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly ReplicaDbContext _context;

        protected OrderRepository(ReplicaDbContext context) =>
            _context = context;
    }
}
