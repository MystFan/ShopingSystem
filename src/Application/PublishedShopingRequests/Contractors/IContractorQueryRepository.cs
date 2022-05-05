namespace ShopingRequestSystem.Application.PublishedShopingRequests.Contractors
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Details;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;

    public interface IContractorQueryRepository : IQueryRepository<Contractor>
    {
        Task<ContractorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
    }
}
