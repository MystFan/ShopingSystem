namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    using MediatR;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Common;

    public class SearchShopingRequestQuery : ShopingRequestQuery, IRequest<SearchShopingRequestModel>
    {
    }
}
