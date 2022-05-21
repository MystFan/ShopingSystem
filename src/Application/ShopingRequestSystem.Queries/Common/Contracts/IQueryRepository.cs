namespace ShopingRequestSystem.Queries.Common.Contracts
{
    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
