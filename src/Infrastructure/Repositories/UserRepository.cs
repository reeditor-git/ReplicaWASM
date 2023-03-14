using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReplicaDbContext _context;

        public UserRepository(ReplicaDbContext context) =>
            _context = context;

        /// <summary>
        /// Method for adding a new user.
        /// </summary>
        /// <param name="user">
        /// User object to be added.
        /// </param>
        public async Task AddAsync(User user)
        {
            Role role = await _context.Roles.FirstAsync(role => role.Name == "user");
            user.RoleId = role.Id;
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method for searching for a user by ID.
        /// </summary>
        /// <param name="id">
        /// ID to search for.
        /// </param>
        /// <returns>
        /// The user object, if it was found.
        /// </returns>
        public async Task<User> GetUserAsync(Guid id) =>
            await _context.Users.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await _context.Users.ToListAsync();

        /// <summary>
        /// Method to search for a user by username.
        /// </summary>
        /// <param name="username">
        /// Username to search by.
        /// </param>
        /// <returns>
        /// Returns a user object by username, if such a user exists in the system.
        /// </returns>
        public async Task<User> GetUserByUsernameAsync(string username) =>
            await _context.Users.Include(role => role.Role)
            .FirstOrDefaultAsync(x => x.Username == username);

        /// <summary>
        /// Method for changing the user role by the passed identifier.
        /// </summary>
        /// <param name="userId">
        /// User ID for which you want to replace the role.
        /// </param>
        /// <param name="roleId">
        /// Role ID with which the current user role will be replaced.
        /// </param>
        public async Task ChangeUserRoleAsync(Guid userId, Guid roleId)
        {
            User user = await _context.Users.FindAsync(userId);

            user.Role = await _context.Roles.FindAsync(roleId);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public async Task BlockUserAsync(Guid id, string reason)
        {
            User user = await _context.Users.FindAsync(id);

            user.Blocked = true;
            user.BlockingReason = reason;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public async Task UnblockUserAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);

            user.Blocked = false;
            user.BlockingReason = String.Empty;

            await _context.SaveChangesAsync();
        }

        //public async Task UpdateUserAsync(User user)
        //{
        //    User oldUser = await _context.Users.FindAsync(user.Id)
        //        ?? throw new Exception($"User with ID '{user.Id}' does not exist");

        //    oldUser.Username = user.Username;
        //    oldUser.FirstName = user.FirstName;
        //    oldUser.LastName = user.LastName;
        //    oldUser.Phone = user.Phone;
        //    oldUser.Email = user.Email;

        //}
    }
}
