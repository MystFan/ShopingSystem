namespace ShopingRequestSystem.Queries.Common.Contracts
{
    public interface IDataSource<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
