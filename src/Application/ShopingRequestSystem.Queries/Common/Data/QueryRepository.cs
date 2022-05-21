namespace ShopingRequestSystem.Queries.Common.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using ShopingRequestSystem.Queries.Common.Contracts;

    internal abstract class QueryRepository<TModel>
        where TModel : class
    {
        protected readonly IDapperConnection connection;

        public QueryRepository(IDapperConnection connection)
        {
            this.connection = connection;
        }

        protected async Task<List<TModel>> AllAsync(string sqlQuery, CancellationToken cancellationToken = default)
        {
            IEnumerable<TModel> result = await this.connection.Instance
                .QueryAsync<TModel>(new CommandDefinition(sqlQuery, cancellationToken: cancellationToken));
            return result.ToList();
        }

        protected async Task<TModel> GetByIdAsync(string sqlQuery, object parameters = default, CancellationToken cancellationToken = default)
        {
            TModel result = await this.connection.Instance
                .QueryFirstOrDefaultAsync<TModel>(new CommandDefinition(sqlQuery, parameters: parameters, cancellationToken: cancellationToken));
            return result;
        }

        protected async Task<int> CountAsync(string sqlQuery, object parameters = default, CancellationToken cancellationToken = default)
        {
            int result = await this.connection.Instance
                .ExecuteScalarAsync<int>(new CommandDefinition(sqlQuery, parameters: parameters, cancellationToken: cancellationToken));
            return result;
        }
    }
}
