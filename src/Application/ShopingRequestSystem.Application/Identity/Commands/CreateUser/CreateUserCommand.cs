namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Identity.Commands.Comman;

    public class CreateUserCommand : UserCommand, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}