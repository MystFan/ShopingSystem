namespace ShopingRequestSystem.Application.ShopingRequests.Requesters
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Details;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public interface IRequesterQueryRepository : IQueryRepository<Requester>
    {
        Task<RequesterDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
    }
}
