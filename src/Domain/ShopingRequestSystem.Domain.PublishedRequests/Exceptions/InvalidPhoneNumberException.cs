namespace ShopingRequestSystem.Domain.PublishedRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string error) => this.Error = error;
    }
}
