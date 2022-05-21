namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Edit
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Common;
    using ShopingRequestSystem.Domain.Requests.Repositories;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.ShopingRequest;

    public class EditShopingRequestCommandValidator : AbstractValidator<EditShopingRequestCommand>
    {
        public EditShopingRequestCommandValidator(
            ICurrentUser currentUser,
            IRequesterDomainRepository requesterRepository)
        {
            Include(new ShopingRequestCommandValidator<EditShopingRequestCommand>(requesterRepository));

            RuleFor(c => c.RequestId)
                .MinimumLength(MinRequestIdLength)
                .MaximumLength(MaxRequestIdLength)
                .NotEmpty();

            RuleFor(c => c.RequesterId)
                .Must(requesterId => currentUser.UserId == requesterId)
                .WithMessage($"You cannot edit the shoping request.");
        }
    }
}
