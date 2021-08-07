using System;
using System.Threading.Tasks;

namespace Services.Resource.Core.Repositories
{
    public interface ITextResourceRepository
    {
        Task<Entities.TextResource> GetAsync(Guid id);
        Task<Entities.TextResource> GetByRouteIdAsync(Guid routeId);
        Task AddAsync(Entities.TextResource textResource);
        Task UpdateAsync(Entities.TextResource textResource);
    }
}