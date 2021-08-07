using System;
using Services.Resource.Core.Exceptions;

namespace Services.Resource.Core.Entities
{
    public class TextResource : AggregateRoot
    {
        private static readonly int TextMaxLength = 400;
        public Guid UserId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Text { get; private set; }
        
        public TextResource(Guid id ,Guid userId, Guid routeId, DateTime createdAt, string text)
        {
            Id = id;
            UserId = userId;
            RouteId = routeId;
            CreatedAt = createdAt;
            if (String.IsNullOrWhiteSpace(text))
                throw new InvalidResourceTextException();
            
            text = text.Trim();
            if (text.Length > TextMaxLength)
                throw new ResourceTextTooLongException(text.Length, TextMaxLength);
            
            Text = text;
        }
    }
}