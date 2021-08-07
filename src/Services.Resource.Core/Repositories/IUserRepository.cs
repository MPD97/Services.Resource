using System;
using System.Threading.Tasks;
using Services.Resource.Core.Entities;

namespace Services.Resource.Core.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}