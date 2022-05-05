namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Commands.Edit
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class EditRequesterCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}
