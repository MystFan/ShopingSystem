namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class ShopingRequestDetailsQuery<TDetailsOutputModel> : EntityQuery<int>, IRequest<TDetailsOutputModel>
    {
    }
}
