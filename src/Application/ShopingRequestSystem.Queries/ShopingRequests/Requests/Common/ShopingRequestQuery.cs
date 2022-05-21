namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Common
{
    public abstract class ShopingRequestQuery
    {
        public string Requester { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? MinPaymentSum { get; set; }

        public decimal? MaxPaymentSum { get; set; }

        public int Status { get; set; } = 1;

        public string SortBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; } = 1;
    }
}
