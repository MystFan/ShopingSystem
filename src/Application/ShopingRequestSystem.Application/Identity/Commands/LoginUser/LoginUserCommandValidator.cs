namespace ShopingRequestSystem.Application.Identity.Commands.LoginUser
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Identity.Commands.Comman;

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
            => Include(new UserCommandValidator());
    }
}
