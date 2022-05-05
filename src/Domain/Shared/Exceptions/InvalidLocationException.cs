namespace ShopingRequestSystem.Domain.Shared.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidLocationException : BaseDomainException
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string error) => this.Error = error;
    }
}
