namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.Common.Data;
    using ShopingRequestSystem.Queries.ShopingRequests;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    internal class RequesterDataSource : DataSource<RequesterDetailsModel>, IRequesterDataSource
    {
        public RequesterDataSource(IDapperConnection connection)
            : base(connection)
        {
        }

        public async Task<RequesterDetailsModel> GetDeatailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await this.GetByIdAsync(SqlQueries.Requester.GetById(), new { Id = id }, cancellationToken);
        }
    }
}
