namespace ShopingRequestSystem.Domain.Requests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Requests.Models;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithUserId(string userId);

        IRequesterFactory WithName(string name);

        IRequesterFactory WithPhoneNumber(string phoneNumber);
    }
}
