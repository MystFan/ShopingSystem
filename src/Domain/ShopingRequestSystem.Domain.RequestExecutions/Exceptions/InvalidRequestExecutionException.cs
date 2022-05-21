namespace ShopingRequestSystem.Domain.RequestExecutions.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidRequestExecutionException : BaseDomainException
    {
        public InvalidRequestExecutionException()
        {
        }

        public InvalidRequestExecutionException(string error) => this.Error = error;
    }
}
