namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}