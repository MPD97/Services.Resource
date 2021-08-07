using System;
using Convey.CQRS.Events;

namespace Services.Resource.Application.Events
{
    [Contract]
    public class TextResourceCreated: IEvent
    {
        public Guid UserId { get; }
        public Guid RouteId { get; }

        public TextResourceCreated(Guid userId, Guid routeId)
        {
            UserId = userId;
            RouteId = routeId;
        }
    }
}