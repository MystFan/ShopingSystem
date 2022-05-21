namespace ShopingRequestSystem.Queries.ShopingRequests.Requests
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;

    public interface IShopingRequestQueryRepository : IQueryRepository<ShopingRequestDetailsModel>
    {
        Task<IEnumerable<ShopingRequestModel>> GetShopingRequestListings(
            Specification<ShopingRequestDetailsModel> requestSpecification,
            ShopingRequestSortOrder requestSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<ShopingRequestDetailsModel> requestSpecification,
            CancellationToken cancellationToken = default);
    }
}
