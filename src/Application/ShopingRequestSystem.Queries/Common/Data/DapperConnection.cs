namespace ShopingRequestSystem.Queries.Common.Data
{
    using Microsoft.Extensions.Options;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using System.Data;
    using System.Data.SqlClient;

    internal class DapperConnection : IDapperConnection
    {
        private readonly ConnectionStrings connectionStrings;

        public DapperConnection(IOptions<ConnectionStrings> connectionStrings)
        {
            this.connectionStrings = connectionStrings.Value;
        }

        public IDbConnection Instance => new SqlConnection(connectionStrings.DefaultConnection);
    }
}
