namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Edit
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Common;

    public class EditShopingRequestCommand : ShopingRequestCommand<EditShopingRequestCommand>, IRequest<Result>
    {
    }
}
