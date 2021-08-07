using System;

namespace Services.Resource.Application.Exceptions
{
    public class RouteNotFoundException : AppException
    {
        public override string Code { get; } = "route_not_found";
        public Guid RouteId { get; }

        public RouteNotFoundException(Guid routeId) : base($"Route with id: {routeId} was not found.")
            => RouteId = routeId;
    }
}