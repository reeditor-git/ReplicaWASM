using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class CommentRepository 
        : BaseRepository, ICommentRepository
    {
        public CommentRepository(ReplicaDbContext ctx)
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Comment comment)
        {
            var newComment = await _ctx.Comments
                .AddAsync(comment);

            await _ctx.SaveChangesAsync();

            return newComment.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var comment = await _ctx.Comments
                .FindAsync(id);

            _ctx.Comments.Remove(comment);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Comment> GetAsync(Guid id) =>
            await _ctx.Comments.FindAsync(id);

        public async Task<IEnumerable<Comment>> GetAllAsync() =>
            await _ctx.Comments.ToListAsync();

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var updateComment = await _ctx.Comments
                .FindAsync(comment.Id);

            updateComment = comment;

            return await Task.FromResult(true);
        }
    }
}
