namespace ShopingRequestSystem.Application.Identity.Commands.ChangePassword
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.Identity.Commands;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IIdentityService identity;

        public ChangePasswordCommandHandler(
            ICurrentUser currentUser,
            IIdentityService identity)
        {
            this.currentUser = currentUser;
            this.identity = identity;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
            => await identity.ChangePassword(new ChangePasswordInputModel(
                currentUser.UserId,
                request.CurrentPassword,
                request.NewPassword));
    }
}
