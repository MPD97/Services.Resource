using System;
using Convey.Types;

namespace Services.Resource.Infrastructure.Mongo.Documents
{
    public class TextResourceDocument: IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}