namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;

    public class ContractorDetailsModel : IAggregateRoot
    {
        public int Id { get; private set; }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public string PhoneNumber { get; private set; }
    }
}
