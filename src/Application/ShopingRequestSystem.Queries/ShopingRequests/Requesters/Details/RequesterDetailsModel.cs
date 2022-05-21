namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;

    public class RequesterDetailsModel : IAggregateRoot
    {
        public int Id { get; private set; }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public string PhoneNumber { get; private set; }
    }
}
