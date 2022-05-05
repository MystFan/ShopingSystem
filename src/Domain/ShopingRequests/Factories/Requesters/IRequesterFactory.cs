namespace ShopingRequestSystem.Domain.ShopingRequests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithUserId(string userId);

        IRequesterFactory WithName(string name);

        IRequesterFactory WithPhoneNumber(string phoneNumber);
    }
}
