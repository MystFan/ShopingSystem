namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Domain.PublishedRequests.Exceptions;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;
    using ShopingRequestSystem.Domain.PublishedRequests.Repositories;

    internal class ContractorRepository : DataRepository<IPublishedShopingRequestDbContext, Contractor>,
        IContractorDomainRepository
    {
        private readonly IMapper mapper;

        public ContractorRepository(IPublishedShopingRequestDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public Task<int> GetContractorId(
            string userId,
            CancellationToken cancellationToken = default)
                => this.FindByUser<int>(userId, contractor => contractor.Id, cancellationToken);

        public Task<Contractor> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
                => this.FindByUser<Contractor>(userId, contractor => contractor, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Contractor, T>> selector,
            CancellationToken cancellationToken = default)
        {
            T contractorData = await this
                .Data
                .Contractors
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (contractorData == null)
            {
                throw new InvalidContractorException("This user is not a shoping request contractor.");
            }

            return contractorData;
        }
    }
}
