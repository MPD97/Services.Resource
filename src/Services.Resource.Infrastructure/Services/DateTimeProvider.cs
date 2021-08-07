using System;
using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Events;
using Services.Resource.Application.Events;
using Services.Resource.Application.Services;
using Services.Resource.Core;

namespace Services.Resource.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now  => DateTime.UtcNow;
    }
    public class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
        {
            switch (@event)
            {
                case Core.Events.TextResourceAdded e: return new Application.Events.TextResourceCreated(e.TextResource.UserId, e.TextResource.RouteId);
            }

            return null;
        }
    }
}