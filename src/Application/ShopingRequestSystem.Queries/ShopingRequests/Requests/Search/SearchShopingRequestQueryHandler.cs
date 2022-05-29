namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Search
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Specifications;

    internal class SearchShopingRequestQueryHandler : 
        IRequestHandler<SearchShopingRequestQuery, SearchShopingRequestModel>
    {
        private const int PerPage = 10;
        private readonly IShopingRequestDataSource shopingRequestDataSource;

        public SearchShopingRequestQueryHandler(IShopingRequestDataSource shopingRequestDataSource)
        {
            this.shopingRequestDataSource = shopingRequestDataSource;
        }

        public async Task<SearchShopingRequestModel> Handle(
            SearchShopingRequestQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<ShopingRequestModel> shopingRequestListings = await GetShopingRequestListings(
                request,
                cancellationToken);

            int totalPages = await GetTotalPages(request, cancellationToken);

            return new SearchShopingRequestModel(shopingRequestListings, request.Page, totalPages);
        }

        private async Task<IEnumerable<ShopingRequestModel>> GetShopingRequestListings(
            SearchShopingRequestQuery request,
            CancellationToken cancellationToken = default)
        {
            Specification<ShopingRequestDetailsModel> requestSpecification = GetShopingRequestSpecification(request);

            var searchOrder = new ShopingRequestSortOrder(request.SortBy, request.Order);

            int skip = (request.Page - 1) * PerPage;

            return await shopingRequestDataSource.GetShopingRequestListings(
                requestSpecification,
                searchOrder,
                skip,
                take: PerPage,
                cancellationToken);
        }

        private async Task<int> GetTotalPages(
            ShopingRequestQuery request,
            CancellationToken cancellationToken = default)
        {
            Specification<ShopingRequestDetailsModel> requestSpecification
                = GetShopingRequestSpecification(request);

            int totalRequests = await shopingRequestDataSource.Total(
                requestSpecification,
                cancellationToken);

            return (int)Math.Ceiling((double)totalRequests / PerPage);
        }

        private Specification<ShopingRequestDetailsModel> GetShopingRequestSpecification(ShopingRequestQuery request)
            => new ShopingRequestByRequesterSpecification(request.Requester)
                .And(new ShopingRequestByPaymentSumSpecification(request.MinPaymentSum, request.MaxPaymentSum))
                .And(new ShopingRequestByNameSpecification(request.Name));
    }
}
