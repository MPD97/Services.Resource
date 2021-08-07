using System;
using Convey.CQRS.Commands;

namespace Services.Resource.Application.Commands
{        
    [Contract]
    public class CreateTextResource :ICommand
    {
        public Guid UserId { get; }
        public Guid RouteId { get; }
        public string Text { get; }
        
        public CreateTextResource(Guid userId, Guid routeId, string text)
        {
            UserId = userId;
            RouteId = routeId;
            Text = text;
        }
    }
}