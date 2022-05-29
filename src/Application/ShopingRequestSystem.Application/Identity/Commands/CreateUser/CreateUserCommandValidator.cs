namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Identity.Commands.Comman;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.User;
    using static ShopingRequestSystem.Domain.Identity.Models.ModelConstants.PhoneNumber;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            Include(new UserCommandValidator());

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
