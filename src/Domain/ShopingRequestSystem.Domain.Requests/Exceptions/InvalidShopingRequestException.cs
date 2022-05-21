namespace ShopingRequestSystem.Domain.Requests.Exceptions
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
