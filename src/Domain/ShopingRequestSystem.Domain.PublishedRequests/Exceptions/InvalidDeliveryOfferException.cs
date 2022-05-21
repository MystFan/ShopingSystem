namespace ShopingRequestSystem.Domain.PublishedRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidDeliveryOfferException : BaseDomainException
    {
        public InvalidDeliveryOfferException()
        {
        }

        public InvalidDeliveryOfferException(string error) => Error = error;
    }
}
