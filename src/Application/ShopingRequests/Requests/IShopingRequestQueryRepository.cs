namespace ShopingRequestSystem.Application.ShopingRequests.Requests
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public interface IShopingRequestQueryRepository : IQueryRepository<Requester>
    {
        Task<ShopingRequestDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TOutputModel>> GetShopingRequestListings<TOutputModel>(
            Specification<ShopingRequest> requestSpecification,
            ShopingRequestSortOrder requestSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<ShopingRequest> requestSpecification,
            CancellationToken cancellationToken = default);
    }
}
