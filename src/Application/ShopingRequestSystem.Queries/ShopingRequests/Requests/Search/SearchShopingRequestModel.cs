namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    using System.Collections.Generic;

    public class SearchShopingRequestModel : ShopingRequestsModel<ShopingRequestModel>
    {
        public SearchShopingRequestModel(
            IEnumerable<ShopingRequestModel> shopingRequests,
            int page,
            int totalPages)
            : base(shopingRequests, page, totalPages)
        {
        }
    }
}
