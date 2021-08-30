using System.Collections.Generic;

namespace Services.Resource.Core.Entities
{
    public interface IAggregateRoot
    {
        IEnumerable<IDomainEvent> Events { get; }
        AggregateId Id { get;  }
    }
}