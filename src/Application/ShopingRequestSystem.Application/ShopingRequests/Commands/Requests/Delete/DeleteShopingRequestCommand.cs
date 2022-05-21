namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Delete
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class DeleteShopingRequestCommand : EntityCommand<int>, IRequest<Result>
    {
    }
}
