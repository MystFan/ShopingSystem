namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    public interface IContractorQueryRepository : IQueryRepository<ContractorDetailsModel>
    {
        Task<ContractorDetailsModel> GetDetails(int id, CancellationToken cancellationToken = default);
    }
}
