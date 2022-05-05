namespace ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class ContractorDetailsQueryHandler : IRequestHandler<ContractorDetailsQuery, ContractorDetailsOutputModel>
    {
        private readonly IContractorQueryRepository contractorRepository;

        public ContractorDetailsQueryHandler(IContractorQueryRepository contractorRepository)
        {
            this.contractorRepository = contractorRepository;
        }

        public async Task<ContractorDetailsOutputModel> Handle(
            ContractorDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.contractorRepository.GetDetails(request.Id, cancellationToken);
    }
}
