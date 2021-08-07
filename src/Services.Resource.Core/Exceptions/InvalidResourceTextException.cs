namespace Services.Resource.Core.Exceptions
{
    public class InvalidResourceTextException : DomainException
    {
        public override string Code { get; } = "invalid_resource_text";

        public InvalidResourceTextException() : base($"Invalid resource text.")
        {
        }
    }
}