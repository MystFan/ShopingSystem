namespace ShopingRequestSystem.Domain.ShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidShopingItemException : BaseDomainException
    {
        public InvalidShopingItemException()
        {
        }

        public InvalidShopingItemException(string error) => this.Error = error;
    }
}
