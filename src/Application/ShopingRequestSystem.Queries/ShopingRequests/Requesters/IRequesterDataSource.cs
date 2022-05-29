namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public interface IRequesterDataSource : IDataSource<RequesterDetailsModel>
    {
        Task<RequesterDetailsModel> GetDeatailsAsync(int id, CancellationToken cancellationToken = default);
    }
}
