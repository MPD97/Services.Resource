using Services.Resource.Core.Entities;

namespace Services.Resource.Application.Exceptions
{
    public class RouteStatusIsNotAcceptedException : AppException
    {
        public override string Code { get; } = "route_status_not_accepted";
        public RouteStatus  Status { get; }

        public RouteStatusIsNotAcceptedException(RouteStatus status) 
            : base($"Route status: {status} is not accepted.")
        {
            Status = status;
        }
    }
}