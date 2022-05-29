namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Details
{
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class ShopingRequestDetailsModel : IAggregateRoot
    {
        public int Id { get; set; }

        public string RequestId { get; set; }

        public int RequesterId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal PaymentSum { get; set; }

        public int Status { get; set; }

        public RequesterDetailsModel Requester { get; set; }
    }
}
