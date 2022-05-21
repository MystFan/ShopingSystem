namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Details
{
    using MediatR;
    using ShopingRequestSystem.Queries.Common;

    public class ShopingRequestDetailsQuery<TDetailsOutputModel> : EntityQuery<int>, IRequest<TDetailsOutputModel>
    {
    }
}
