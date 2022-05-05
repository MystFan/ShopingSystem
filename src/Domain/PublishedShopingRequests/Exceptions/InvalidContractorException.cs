namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions
{
    using Common;

    public class InvalidContractorException : BaseDomainException
    {
        public InvalidContractorException()
        {
        }

        public InvalidContractorException(string error) => this.Error = error;
    }
}
