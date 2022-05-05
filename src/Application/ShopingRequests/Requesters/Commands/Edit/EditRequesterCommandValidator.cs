namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Commands.Edit
{
    using FluentValidation;
    using static Domain.ShopingRequests.Models.ModelConstants.Requester;
    using static Domain.Shared.ModelConstants.PhoneNumber;

    public class EditRequesterCommandValidator : AbstractValidator<EditRequesterCommand>
    {
        public EditRequesterCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
