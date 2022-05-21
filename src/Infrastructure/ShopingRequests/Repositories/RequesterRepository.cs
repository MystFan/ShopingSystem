namespace ShopingRequestSystem.Infrastructure.ShopingRequests.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.Requests.Exceptions;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal class RequesterRepository : DataRepository<IShopingRequestDbContext, Requester>,
        IRequesterDomainRepository
    {
        private readonly IMapper mapper;

        public RequesterRepository(IShopingRequestDbContext db, IMapper mapper)
            : base(db) 
            => this.mapper = mapper;

        public Task<int> GetRequesterId(
            string userId, 
            CancellationToken cancellationToken = default)
            => this.FindByUser<int>(userId, requester => requester.Id, cancellationToken);

        public Task<Requester> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser<Requester>(userId, requester => requester, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Requester, T>> selector,
            CancellationToken cancellationToken = default)
        {
            T requesterData = await this
                .Data
                .Requesters
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (requesterData == null)
            {
                throw new InvalidRequesterException("This user is not a shoping requester.");
            }

            return requesterData;
        }
    }
}
