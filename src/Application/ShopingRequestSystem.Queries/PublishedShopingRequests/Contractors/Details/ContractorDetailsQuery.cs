namespace ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details
{
    using MediatR;
    using ShopingRequestSystem.Queries.Common;

    public class ContractorDetailsQuery<TDetailsOutputModel> : EntityQuery<int>, IRequest<TDetailsOutputModel>
    {
    }
}
