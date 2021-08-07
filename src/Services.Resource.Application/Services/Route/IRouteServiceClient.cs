using System;
using System.Threading.Tasks;
using Services.Resource.Application.DTO;

namespace Services.Resource.Application.Services.Route
{
    public interface IRouteServiceClient
    {
        Task<RouteDto> GetAsync(Guid id);
    }
}