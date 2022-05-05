namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    
    public interface IContractorFactory : IFactory<Contractor>
    {
        IContractorFactory WithUserId(string userId);

        IContractorFactory WithName(string name);

        IContractorFactory WithPhoneNumber(string phoneNumber);
    }
}
