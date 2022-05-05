namespace ShopingRequestSystem.Domain.ShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidShopingAddressException : BaseDomainException
    {
        public InvalidShopingAddressException()
        {
        }

        public InvalidShopingAddressException(string error) => this.Error = error;
    }
}
