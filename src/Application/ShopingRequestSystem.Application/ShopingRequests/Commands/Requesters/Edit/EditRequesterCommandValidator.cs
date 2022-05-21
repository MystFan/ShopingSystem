namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requesters.Edit
{
    using FluentValidation;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Requester;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.PhoneNumber;

    public class EditRequesterCommandValidator : AbstractValidator<EditRequesterCommand>
    {
        public EditRequesterCommandValidator()
        {
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
