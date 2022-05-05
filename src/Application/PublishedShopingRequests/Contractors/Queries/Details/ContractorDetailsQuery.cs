namespace ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Details
{
    using MediatR;

    public class ContractorDetailsQuery : IRequest<ContractorDetailsOutputModel>
    {
        public int Id { get; set; }
    }
}
