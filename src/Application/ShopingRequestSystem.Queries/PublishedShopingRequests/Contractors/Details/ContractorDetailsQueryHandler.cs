namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ContractorDetailsQueryHandler : IRequestHandler<ContractorDetailsQuery<ContractorDetailsModel>, ContractorDetailsModel>
    {
        private readonly IContractorQueryRepository contractorRepository;

        public ContractorDetailsQueryHandler(IContractorQueryRepository contractorRepository)
        {
            this.contractorRepository = contractorRepository;
        }

        public async Task<ContractorDetailsModel> Handle(
            ContractorDetailsQuery<ContractorDetailsModel> request,
            CancellationToken cancellationToken)
            => await contractorRepository.GetDetails(request.Id, cancellationToken);
    }
}
