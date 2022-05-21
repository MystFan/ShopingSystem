namespace ShopingRequestSystem.Queries.Common.Contracts
{
    using System.Data;

    internal interface IDapperConnection
    {
        IDbConnection Instance { get; }
    }
}
