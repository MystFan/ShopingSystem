namespace ShopingRequestSystem.Domain.Requests.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Requests.Models;

    public interface IRequesterDomainRepository : IDomainRepository<Requester>
    {
        Task<Requester> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetRequesterId(string userId, CancellationToken cancellationToken = default);
    }
}
