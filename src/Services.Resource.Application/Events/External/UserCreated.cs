using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Services.Resource.Core.Entities;

namespace Services.Resource.Application.Events.External
{
    [Message("users")]
    public class UserCreated: IEvent
    {
        public Guid UserId { get; }
        
        public State State { get; }

        public UserCreated(Guid userId, State state)
        {
            UserId = userId;
            State = state;
        }
    }
}