namespace ShopingRequestSystem.Queries.ShopingRequests.Requests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.Common.Data;
    using ShopingRequestSystem.Queries.ShopingRequests;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;

    internal class ShopingRequestQueryRepository : QueryRepository<ShopingRequestDetailsModel>, IShopingRequestQueryRepository
    {
        public ShopingRequestQueryRepository(IDapperConnection connection)
            : base(connection) 
        {
        }

        public async Task<ShopingRequestDetailsModel> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await this.GetByIdAsync(SqlQueries.ShopingRequest.GetById(), new { Id = id }, cancellationToken);
        }

        public async Task<IEnumerable<ShopingRequestModel>> GetShopingRequestListings(
            Specification<ShopingRequestDetailsModel> requestSpecification,
            ShopingRequestSortOrder requestSortOrder, 
            int skip = 0, 
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> dictionary = requestSpecification
                .ToSqlParameters()
                .ToDictionary(k => k.ParameterName, v => v.Value);
            dictionary.Add("Skip", skip);
            dictionary.Add("Take", take);

            var parameters = new DynamicParameters(dictionary);
            IEnumerable<ShopingRequestModel> result = await this.connection.Instance
                .QueryAsync<ShopingRequestModel>(
                new CommandDefinition(
                    SqlQueries.ShopingRequest.Paged(requestSpecification.ToSql(), requestSortOrder.ToSql(), requestSortOrder.Order), 
                    parameters: parameters, 
                    cancellationToken: cancellationToken)
                );

            return result;
        }

        public async Task<int> Total(
            Specification<ShopingRequestDetailsModel> requestSpecification, 
            CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> dictionary = requestSpecification
                .ToSqlParameters()
                .ToDictionary(k => k.ParameterName, v => v.Value);

            var parameters = new DynamicParameters(dictionary);
            int total = await this.CountAsync(
                SqlQueries.ShopingRequest.Count(requestSpecification.ToSql()), 
                parameters,
                cancellationToken);

            return total;
        }
    }
}
