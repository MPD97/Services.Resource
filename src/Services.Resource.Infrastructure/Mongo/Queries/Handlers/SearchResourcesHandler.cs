using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Services.Resource.Application.DTO;
using Services.Resource.Application.Queries;
using Services.Resource.Infrastructure.Mongo.Documents;

namespace Services.Resource.Infrastructure.Mongo.Queries.Handlers
{
    public class SearchResourcesHandler: IQueryHandler<SearchResources, PagedResult<TextResourceDto>>
    {
        private readonly IMongoRepository<TextResourceDocument, Guid> _repository;

        public SearchResourcesHandler(IMongoRepository<TextResourceDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<TextResourceDto>> HandleAsync(SearchResources query)
        {
            Expression<Func<TextResourceDocument, bool>> predicate = r => r.RouteId == query.RouteId;

            var pagedResult = await _repository.BrowseAsync(predicate, query);
            return pagedResult?.Map(d => d.AsDto());      
        }
    }
}