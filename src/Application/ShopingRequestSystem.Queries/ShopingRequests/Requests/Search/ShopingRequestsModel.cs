namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    using System.Collections.Generic;

    public abstract class ShopingRequestsModel<TShopingRequestOutputModel>
    {
        public ShopingRequestsModel(
            IEnumerable<TShopingRequestOutputModel> shopingRequests,
            int page,
            int totalPages)
        {
            ShopingRequests = shopingRequests;
            Page = page;
            TotalPages = totalPages;
        }

        public IEnumerable<TShopingRequestOutputModel> ShopingRequests { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
