namespace ShopingRequestSystem.Infrastructure.ShopingRequests.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Application.ShopingRequests.Requests;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;
    using ShopingRequestSystem.Infrastructure.Common;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal class ShopingRequestRepository : DataRepository<IShopingRequestDbContext, ShopingRequest>,
        IShopingRequestDomainRepository,
        IShopingRequestQueryRepository
    {
        private readonly IMapper mapper;

        public ShopingRequestRepository(IShopingRequestDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<ShopingRequest> Find(int id, CancellationToken cancellationToken = default)
            => await this.All()
                .Include(r => r.Requester)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        public async Task<ShopingRequestDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                    .ProjectTo<ShopingRequestDetailsOutputModel>(this
                    .All()
                    .Include(sr => sr.Requester)
                    .Where(sr => sr.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<bool> RequesterHasShopingRequest(string userId, int shopingRequestId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(sr => sr.Requester)
                .Where(sr => sr.Id == shopingRequestId)
                .AnyAsync(sr => sr.Id == shopingRequestId && sr.Requester.UserId == userId, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            ShopingRequest shopingRequest = await this.Data.ShopingRequests.FindAsync(id);
            if (shopingRequest == null)
            {
                return false;
            }

            this.Data.ShopingRequests.Remove(shopingRequest);

            await this.Data.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetShopingRequestListings<TOutputModel>(
            Specification<ShopingRequest> requestSpecification,
            ShopingRequestSortOrder requestSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this
                    .GetShopingRequestQuery(requestSpecification)
                    .Sort(requestSortOrder))
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take);

        public async Task<int> Total(
            Specification<ShopingRequest> requestSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetShopingRequestQuery(requestSpecification)
                .CountAsync(cancellationToken);

        private IQueryable<ShopingRequest> GetShopingRequestQuery(
            Specification<ShopingRequest> requestSpecification)
            => this
                .Data
                .ShopingRequests
                .Where(requestSpecification);
    }
}
