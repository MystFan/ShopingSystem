namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.Common.Data;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    internal class ContractorDataSource : DataSource<ContractorDetailsModel>
    {
        public ContractorDataSource(IDapperConnection connection)
            : base(connection)
        {
        }

        public async Task<ContractorDetailsModel> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await this.GetByIdAsync(SqlQueries.Contractor.GetById(), new { Id = id }, cancellationToken);
        }
    }
}
