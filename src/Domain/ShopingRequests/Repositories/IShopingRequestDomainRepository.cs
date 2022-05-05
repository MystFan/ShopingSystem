namespace ShopingRequestSystem.Domain.ShopingRequests.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public interface IShopingRequestDomainRepository : IDomainRepository<ShopingRequest>
    {
        Task<ShopingRequest> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> RequesterHasShopingRequest(string userId, int shopingRequestId, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
