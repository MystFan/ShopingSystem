namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.ChangeStatus
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class ChangeStatusCommand : EntityCommand<int>, IRequest<Result>
    {
        public int NewStatus { get; set; }
    }
}
