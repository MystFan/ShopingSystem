namespace ShopingRequestSystem.Infrastructure.Identity
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.Identity.Exceptions;
    using ShopingRequestSystem.Domain.Identity.Repositories;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal class UserRepository : DataRepository<IIdentityDbContext, User>, IUserDomainRepository
    {
        public UserRepository(IIdentityDbContext db)
            : base(db)
        { 
        }

        public async Task<string> GetUserId(string userName, CancellationToken cancellationToken = default)
        {
            string userId = await this
                .Data
                .Users
                .Where(u => u.UserName == userName)
                .Select(u => u.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (userId == null)
            {
                throw new InvalidUserException("This user not exists.");
            }

            return userId;
        }
    }
}
