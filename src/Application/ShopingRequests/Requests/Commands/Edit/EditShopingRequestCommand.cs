namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Edit
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common;

    public class EditShopingRequestCommand : ShopingRequestCommand<EditShopingRequestCommand>, IRequest<Result>
    {
    }
}
