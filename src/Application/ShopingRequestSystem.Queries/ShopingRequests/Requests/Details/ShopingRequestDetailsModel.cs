namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class ShopingRequestDetailsModel : IAggregateRoot
    {
        public int Id { get; private set; }

        public string RequestId { get; private set; }

        public int RequesterId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DeliveryAddress { get; private set; }

        public decimal PaymentSum { get; private set; }

        public int Status { get; private set; }

        public RequesterDetailsModel Requester { get; set; }
    }
}
