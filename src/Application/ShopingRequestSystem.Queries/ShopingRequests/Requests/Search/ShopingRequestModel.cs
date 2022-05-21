namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    public class ShopingRequestModel
    {
        public int Id { get; private set; }

        public string RequestId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DeliveryAddress { get; private set; }

        public decimal PaymentSum { get; private set; }

        public int Status { get; private set; }

        public int RequesterId { get; private set; }

        public string UserId { get; private set; }

        public string RequesterName { get; private set; }

        public string RequesterPhoneNumber { get; private set; }
    }
}
