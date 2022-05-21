namespace ShopingRequestSystem.Domain.Identity.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUserDomainRepository
    {
        Task<string> GetUserId(string userName, CancellationToken cancellationToken = default);
    }
}
