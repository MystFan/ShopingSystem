namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common
{
    using System.Collections.Generic;

    public abstract class ShopingRequestsOutputModel<TShopingRequestOutputModel>
    {
        internal ShopingRequestsOutputModel(
            IEnumerable<TShopingRequestOutputModel> shopingRequests, 
            int page, 
            int totalPages)
        {
            this.ShopingRequests = shopingRequests;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TShopingRequestOutputModel> ShopingRequests { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
