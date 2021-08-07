using System.Collections.Generic;
using Convey.CQRS.Events;
using Services.Resource.Core;

namespace Services.Resource.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}