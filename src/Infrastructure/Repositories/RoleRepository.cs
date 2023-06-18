using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class RoleRepository 
        : BaseRepository, IRoleRepository
    {
        public RoleRepository(ReplicaDbContext ctx) 
            : base(ctx) { }

        public async Task<Role> GetAsync(Guid id) =>
            await _ctx.Roles.FindAsync(id);

        public async Task<IEnumerable<Role>> GetAllAsync() =>
            await _ctx.Roles.ToListAsync();
    }
}
