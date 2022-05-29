namespace ShopingRequestSystem.Application.Identity.Commands.ChangePassword
{
    using FluentValidation;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.User;

    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(u => u.CurrentPassword)
                .MaximumLength(MaxPasswordLength)
                .NotEmpty();

            RuleFor(u => u.NewPassword)
                .MaximumLength(MaxPasswordLength)
                .NotEmpty();
        }
    }
}
