namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.PublishedShopingRequests.Contractors;
    using ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Details;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Repositories;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal class ContractorRepository : DataRepository<IPublishedShopingRequestDbContext, Contractor>,
        IContractorDomainRepository,
        IContractorQueryRepository
    {
        private readonly IMapper mapper;

        public ContractorRepository(IPublishedShopingRequestDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<ContractorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ContractorDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

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
