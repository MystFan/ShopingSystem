namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;

    public class SearchShopingRequestQueryHandler : ShopingRequestQueryHandler, IRequestHandler<
        SearchShopingRequestQuery,
        SearchShopingRequestOutputModel>
    {
        private readonly IShopingRequestQueryRepository shopingRequestRepository;

        public SearchShopingRequestQueryHandler(IShopingRequestQueryRepository shopingRequestRepository)
            : base(shopingRequestRepository)
        {
            this.shopingRequestRepository = shopingRequestRepository;
        }

        public async Task<SearchShopingRequestOutputModel> Handle(
            SearchShopingRequestQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<ShopingRequestOutputModel> shopingRequestListings = await base.GetCarAdListings<ShopingRequestOutputModel>(
                request,
                cancellationToken: cancellationToken);

            int totalPages = await base.GetTotalPages(
                request,
                cancellationToken: cancellationToken);

            return new SearchShopingRequestOutputModel(shopingRequestListings, request.Page, totalPages);
        }
    }
}
