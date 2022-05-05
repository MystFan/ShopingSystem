namespace ShopingRequestSystem.Domain.ShopingRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidShopingRequestException : BaseDomainException
    {
        public InvalidShopingRequestException()
        {
        }

        public InvalidShopingRequestException(string error) => this.Error = error;
    }
}
