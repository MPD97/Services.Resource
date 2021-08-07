using System;
using Convey.CQRS.Queries;
using Services.Resource.Application.DTO;

namespace Services.Resource.Application.Queries
{
    public class SearchResources: PagedQueryBase, IQuery<PagedResult<TextResourceDto>>
    {
        public Guid RouteId { get; set; }
    }
} 