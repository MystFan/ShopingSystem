namespace ShopingRequestSystem.Domain.Identity.Exceptions
{
    using ShopingRequestSystem.Domain.Common;

    public class InvalidUserException : BaseDomainException
    {
        public InvalidUserException()
        {
        }

        public InvalidUserException(string error) => this.Error = error;
    }
}
