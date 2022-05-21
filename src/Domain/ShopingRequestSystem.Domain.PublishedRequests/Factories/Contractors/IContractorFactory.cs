namespace ShopingRequestSystem.Domain.PublishedRequests.Factories.Contractors
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;

    public interface IContractorFactory : IFactory<Contractor>
    {
        IContractorFactory WithUserId(string userId);

        IContractorFactory WithName(string name);

        IContractorFactory WithPhoneNumber(string phoneNumber);
    }
}
