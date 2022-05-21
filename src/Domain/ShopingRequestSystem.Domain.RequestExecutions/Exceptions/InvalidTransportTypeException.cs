namespace ShopingRequestSystem.Domain.RequestExecutions.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidTransportTypeException : BaseDomainException
    {
        public InvalidTransportTypeException()
        {
        }

        public InvalidTransportTypeException(string error) => this.Error = error;
    }
}
