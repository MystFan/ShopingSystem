namespace ShopingRequestSystem.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Identity.Commands;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
    }
}
