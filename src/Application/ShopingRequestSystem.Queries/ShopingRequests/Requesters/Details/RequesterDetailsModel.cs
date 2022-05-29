namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;

    public class RequesterDetailsModel : IAggregateRoot
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
