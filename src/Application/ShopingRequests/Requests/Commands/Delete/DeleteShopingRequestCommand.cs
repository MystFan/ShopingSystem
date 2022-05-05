namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Delete
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class DeleteShopingRequestCommand : EntityCommand<int>, IRequest<Result>
    {
    }
}
