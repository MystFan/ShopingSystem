namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    public class ShopingRequestModel
    {
        public int Id { get; set; }

        public string RequestId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal PaymentSum { get; set; }

        public int Status { get; set; }

        public int RequesterId { get; set; }

        public string UserId { get; set; }

        public string RequesterName { get; set; }

        public string RequesterPhoneNumber { get; set; }
    }
}
