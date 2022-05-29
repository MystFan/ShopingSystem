namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;

    public class ContractorDetailsModel : IAggregateRoot
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
