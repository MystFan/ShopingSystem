namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Create
{
    using MediatR;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common;

    public class CreateShopingRequestCommand : ShopingRequestCommand<CreateShopingRequestCommand>, IRequest<CreateShopingRequestOutputModel>
    {
    }
}
