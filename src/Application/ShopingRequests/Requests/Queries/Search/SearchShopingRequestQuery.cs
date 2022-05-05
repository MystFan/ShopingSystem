namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Search
{
    using MediatR;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;

    public class SearchShopingRequestQuery : ShopingRequestQuery, IRequest<SearchShopingRequestOutputModel>
    {
    }
}
