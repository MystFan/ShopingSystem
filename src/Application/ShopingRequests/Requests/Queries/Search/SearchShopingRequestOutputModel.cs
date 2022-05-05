namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Search
{
    using System.Collections.Generic;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;

    public class SearchShopingRequestOutputModel : ShopingRequestsOutputModel<ShopingRequestOutputModel>
    {
        public SearchShopingRequestOutputModel(
            IEnumerable<ShopingRequestOutputModel> shopingRequests, 
            int page, 
            int totalPages) 
            : base(shopingRequests, page, totalPages)
        {
        }
    }
}
