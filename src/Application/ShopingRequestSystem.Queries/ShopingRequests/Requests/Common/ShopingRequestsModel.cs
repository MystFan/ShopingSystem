namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Common
{
    using System.Collections.Generic;

    public abstract class ShopingRequestsModel<TShopingRequestOutputModel>
    {
        internal ShopingRequestsModel(
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
