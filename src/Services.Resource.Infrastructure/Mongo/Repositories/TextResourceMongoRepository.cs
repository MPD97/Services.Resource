using System;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Services.Resource.Core.Entities;
using Services.Resource.Core.Repositories;
using Services.Resource.Infrastructure.Mongo.Documents;

namespace Services.Resource.Infrastructure.Mongo.Repositories
{
    public class TextResourceMongoRepository : ITextResourceRepository
    {
        private readonly IMongoRepository<TextResourceDocument, Guid> _repository;

        public TextResourceMongoRepository(IMongoRepository<TextResourceDocument, Guid> repository)
        {
            _repository = repository;
        }


        public async Task<TextResource> GetAsync(Guid id)
        {
            var route = await _repository.GetAsync(o => o.Id == id);

            return route?.AsEntity();
        }

        public async Task<TextResource> GetByRouteIdAsync(Guid routeId)
        {
            var textResource = await _repository.FindAsync(r => r.RouteId == routeId);

            return textResource?.Single().AsEntity();
        }


        public async Task AddAsync(TextResource textResource)
            => await _repository.AddAsync(textResource.AsDocument());

        public async Task UpdateAsync(TextResource textResource)
            => await _repository.UpdateAsync(textResource.AsDocument());
    }
}