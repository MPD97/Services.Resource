using Services.Resource.Core.Entities;

namespace Services.Resource.Core.Events
{
    public class TextResourceAdded: IDomainEvent
    {
        public TextResource TextResource { get; }

        public TextResourceAdded(TextResource textResource)
        {
            TextResource = textResource;
        }
    }
}