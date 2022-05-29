namespace ShopingRequestSystem.Application.Identity.Commands.Comman
{
    using FluentValidation;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.User;

    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            RuleFor(u => u.Password)
                .MaximumLength(MaxPasswordLength)
                .NotEmpty();
        }
    }
}
