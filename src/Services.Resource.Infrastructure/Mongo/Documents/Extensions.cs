using Services.Resource.Application.DTO;
using Services.Resource.Core.Entities;

namespace Services.Resource.Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static Core.Entities.TextResource AsEntity(this TextResourceDocument document)
            => new Core.Entities.TextResource(document.Id, document.UserId, document.RouteId, document.CreatedAt,
                document.Text);

        public static TextResourceDocument AsDocument(this Core.Entities.TextResource entity)
            => new TextResourceDocument
            {
                Id = entity.Id,
                UserId = entity.UserId,
                RouteId = entity.RouteId,
                CreatedAt = entity.CreatedAt,
                Text = entity.Text
            };

        public static TextResourceDto AsDto(this TextResourceDocument document)
            => new TextResourceDto
            {
                Id = document.Id,
                UserId = document.UserId,
                RouteId = document.RouteId,
                CreatedAt = document.CreatedAt,
                Text = document.Text
            };

        public static User AsEntity(this UserDocument document)
            => new User(document.Id, document.State);

        public static UserDocument AsDocument(this User entity)
            => new UserDocument
            {
                Id = entity.Id,
                State = entity.State
            };
    }
}