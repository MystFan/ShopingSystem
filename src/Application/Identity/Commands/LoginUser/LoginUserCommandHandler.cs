namespace ShopingRequestSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
    {
        private readonly IIdentityService identity;

        public LoginUserCommandHandler(IIdentityService identity)
        {
            this.identity = identity;
        }

        public async Task<Result<LoginOutputModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            Result<LoginSuccessModel> result = await this.identity.Login(request);

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            LoginSuccessModel user = result.Data;

            return new LoginOutputModel(user.Token);
        }
    }
}
