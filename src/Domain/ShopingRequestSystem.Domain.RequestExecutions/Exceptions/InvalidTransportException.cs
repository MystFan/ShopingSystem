namespace ShopingRequestSystem.Domain.RequestExecutions.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidTransportException : BaseDomainException
    {
        public InvalidTransportException()
        {
        }

        public InvalidTransportException(string error) => this.Error = error;
    }
}
