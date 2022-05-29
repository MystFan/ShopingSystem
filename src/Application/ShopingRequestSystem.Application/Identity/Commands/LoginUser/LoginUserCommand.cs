namespace ShopingRequestSystem.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Identity.Commands.Comman;

    public class LoginUserCommand : UserCommand, IRequest<Result<LoginOutputModel>>
    {
    }
}
