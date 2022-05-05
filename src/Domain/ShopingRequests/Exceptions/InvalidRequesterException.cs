namespace ShopingRequestSystem.Domain.ShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidRequesterException : BaseDomainException
    {
        public InvalidRequesterException()
        {
        }

        public InvalidRequesterException(string error) => this.Error = error;
    }
}
