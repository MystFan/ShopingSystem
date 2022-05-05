namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requesters;
    using ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requests;

    public abstract class ShopingRequestQueryHandler
    {
        private const int PerPage = 10;
        private readonly IShopingRequestQueryRepository shopingRequestRepository;

        protected ShopingRequestQueryHandler(IShopingRequestQueryRepository shopingRequestRepository)
            => this.shopingRequestRepository = shopingRequestRepository;

        protected async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            ShopingRequestQuery request,
            int? requesterId = default,
            CancellationToken cancellationToken = default)
        {
            Specification<ShopingRequest> requestSpecification = this.GetShopingRequestSpecification(request);

            var searchOrder = new ShopingRequestSortOrder(request.SortBy, request.Order);

            int skip = (request.Page - 1) * PerPage;

            return await this.shopingRequestRepository.GetShopingRequestListings<TOutputModel>(
                requestSpecification,
                searchOrder,
                skip,
                take: PerPage,
                cancellationToken);
        }

        protected async Task<int> GetTotalPages(
            ShopingRequestQuery request,
            int? requesterId = default,
            CancellationToken cancellationToken = default)
        {
            Specification<ShopingRequest> requestSpecification 
                = this.GetShopingRequestSpecification(request);

            int totalRequests = await this.shopingRequestRepository.Total(
                requestSpecification,
                cancellationToken);

            return (int)Math.Ceiling((double)totalRequests / PerPage);
        }

        private Specification<ShopingRequest> GetShopingRequestSpecification(ShopingRequestQuery request)
            => new ShopingRequestByRequesterSpecification(request.Requester)
                .And(new ShopingRequestByPaymentSumSpecification(request.MinPaymentSum, request.MaxPaymentSum))
                .And(new ShopingRequestByNameSpecification(request.Name));

        private Specification<Requester> GetRequesterSpecification(ShopingRequestQuery request, int? requesterId)
            => new RequesterByIdSpecification(requesterId)
                .And(new RequesterByNameSpecification(request.Requester));
    }
}
