using System;
using Services.Resource.Core.Entities;

namespace Services.Resource.Application.Exceptions
{
    public class InvalidRouteStatusException : AppException
    {
        public override string Code { get; } = "invalid_route_status";
        public Guid UserId { get; }
        public RouteStatus  Status { get; }

        public InvalidRouteStatusException(Guid userId, RouteStatus routeStatus) 
            : base($"User with id: {userId} has given invalid route status: {routeStatus}.")
        {
            UserId = userId;
            Status = routeStatus;
        }
    }
}