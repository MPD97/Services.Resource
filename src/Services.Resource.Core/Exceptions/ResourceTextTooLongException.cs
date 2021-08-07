namespace Services.Resource.Core.Exceptions
{
    public class ResourceTextTooLongException : DomainException
    {
        public override string Code { get; } = "resource_text_too_long";
        
        public int GivenLength { get; }
        public int MaxLength { get; }

        public ResourceTextTooLongException(int givenLength, int maxLength) : base($"Resource text is too long." +
            $" Maximum lenght is: {maxLength} but given: {givenLength}.")
        {
            GivenLength = givenLength;
            MaxLength = maxLength;
        }
    }
}