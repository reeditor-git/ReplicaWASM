﻿using Replica.Domain.Entities;

namespace Replica.Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Guid> CreateAsync(Category category);
        Task DeleteAsync(Guid id);
        Task<Category> GetAsync(Guid id);
        Task<Category> GetByNameAsync(string name);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<bool> UpdateAsync(Category category);
    }
}
