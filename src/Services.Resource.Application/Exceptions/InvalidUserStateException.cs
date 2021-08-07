using System;
using Services.Resource.Core.Entities;

namespace Services.Resource.Application.Exceptions
{
    public class InvalidUserStateException : AppException
    {
        public override string Code { get; } = "invalid_user_state";
        public Guid UserId { get; }
        public State State { get; }

        public InvalidUserStateException(Guid userId, State state) 
            : base($"User with id: {userId} has invalid state: {state}.")
        {
            UserId = userId;
            State = state;
        }
    }
}