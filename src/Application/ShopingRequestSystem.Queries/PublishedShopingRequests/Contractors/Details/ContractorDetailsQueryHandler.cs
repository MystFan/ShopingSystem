namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ContractorDetailsQueryHandler : IRequestHandler<ContractorDetailsQuery<ContractorDetailsModel>, ContractorDetailsModel>
    {
        private readonly IContractorDataSource contractorDataSource;

        public ContractorDetailsQueryHandler(IContractorDataSource contractorDataSource)
        {
            this.contractorDataSource = contractorDataSource;
        }

        public async Task<ContractorDetailsModel> Handle(
            ContractorDetailsQuery<ContractorDetailsModel> request,
            CancellationToken cancellationToken)
            => await contractorDataSource.GetDetails(request.Id, cancellationToken);
    }
}
