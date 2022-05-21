namespace ShopingRequestSystem.Domain.PublishedRequests.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidContractorException : BaseDomainException
    {
        public InvalidContractorException()
        {
        }

        public InvalidContractorException(string error) => Error = error;
    }
}
