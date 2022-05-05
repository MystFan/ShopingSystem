namespace ShopingRequestSystem.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
    }
}
