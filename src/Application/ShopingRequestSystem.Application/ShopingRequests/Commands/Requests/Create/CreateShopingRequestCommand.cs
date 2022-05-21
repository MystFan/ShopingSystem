namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create
{
    using MediatR;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Common;

    public class CreateShopingRequestCommand : ShopingRequestCommand<CreateShopingRequestCommand>, IRequest<CreateShopingRequestOutputModel>
    {
    }
}
