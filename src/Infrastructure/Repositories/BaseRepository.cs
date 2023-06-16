using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ReplicaDbContext _ctx;

        public BaseRepository(ReplicaDbContext ctx) =>
            _ctx = ctx;
    }
}
