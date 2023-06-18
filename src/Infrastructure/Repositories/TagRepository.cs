using Microsoft.EntityFrameworkCore;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.Entities;
using Replica.Infrastructure.Context;

namespace Replica.Infrastructure.Repositories
{
    public class TagRepository 
        : BaseRepository, ITagRepository
    {
        public TagRepository(ReplicaDbContext ctx)
            : base(ctx) { }

        public async Task<Guid> CreateAsync(Tag tag)
        {
            var newTag = await _ctx.Tags
                .AddAsync(tag);
            await _ctx.SaveChangesAsync();

            return newTag.Entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var tag = await _ctx.Tags
                .FindAsync(id);
            _ctx.Tags.Remove(tag);

            await _ctx.SaveChangesAsync();
        }

        public async Task<Tag> GetAsync(Guid id) =>
            await _ctx.Tags.FindAsync(id);

        public async Task<Tag> GetByNameAsync(string name) =>
            await _ctx.Tags.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<Tag>> GetAllAsync() =>
            await _ctx.Tags.ToListAsync();

        public async Task<bool> UpdateAsync(Tag tag)
        {
            var updateTag = await _ctx.Tags
                .FindAsync(tag.Id);

            updateTag = tag;

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
