namespace ShopingRequestSystem.Domain.PublishedRequests.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;

    public interface IContractorDomainRepository : IDomainRepository<Contractor>
    {
        Task<Contractor> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetContractorId(string userId, CancellationToken cancellationToken = default);
    }
}
