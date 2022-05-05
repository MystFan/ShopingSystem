namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidDeliveryOfferException : BaseDomainException
    {
        public InvalidDeliveryOfferException()
        {
        }

        public InvalidDeliveryOfferException(string error) => this.Error = error;
    }
}
