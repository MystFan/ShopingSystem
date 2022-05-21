namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details
{
    using MediatR;
    using ShopingRequestSystem.Queries.Common;

    public class RequesterDetailsQuery<TDetailsOutputModel> : EntityQuery<int>, IRequest<TDetailsOutputModel>
    {
    }
}
