namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidPublishedShopingRequestException : BaseDomainException
    {
        public InvalidPublishedShopingRequestException()
        {
        }

        public InvalidPublishedShopingRequestException(string error) => this.Error = error;
    }
}
