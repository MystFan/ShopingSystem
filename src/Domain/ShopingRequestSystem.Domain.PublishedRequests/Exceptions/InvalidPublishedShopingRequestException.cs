namespace ShopingRequestSystem.Domain.PublishedRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidPublishedShopingRequestException : BaseDomainException
    {
        public InvalidPublishedShopingRequestException()
        {
        }

        public InvalidPublishedShopingRequestException(string error) => Error = error;
    }
}
