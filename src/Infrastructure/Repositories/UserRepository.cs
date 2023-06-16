using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ReplicaDbContext ctx)
            : base(ctx) { }

        public async Task<Guid> CreateAsync(User user)
        {
            user.Role = await _ctx.Roles.FirstOrDefaultAsync(x => x.Name == "user");
            var newUser = await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();

            return newUser.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _ctx.Users.FindAsync(id);

            _ctx.Users.Remove(user);

            await _ctx.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id) =>
            await _ctx.Users.FindAsync(id);

        public async Task<User> GetByEmailAsync(string email) =>
            await _ctx.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _ctx.Users.ToListAsync();

        public async Task UpdateAsync(User user)
        {
            var updateUser = await _ctx.Users.FindAsync(user.Id);

            updateUser = user;

            await _ctx.SaveChangesAsync();
        }
    }
}
