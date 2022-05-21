namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using FluentValidation;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.User;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.PhoneNumber;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            RuleFor(u => u.Password)
                .MaximumLength(MaxPasswordLength)
                .NotEmpty();

            RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
