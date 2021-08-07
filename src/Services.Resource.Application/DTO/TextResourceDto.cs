using System;

namespace Services.Resource.Application.DTO
{
    public class TextResourceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }

        public TextResourceDto()
        {
        }

        public TextResourceDto(Guid id, Guid userId, Guid routeId, DateTime createdAt, string text)
        {
            Id = id;
            UserId = userId;
            RouteId = routeId;
            CreatedAt = createdAt;
            Text = text;
        }
    }
}