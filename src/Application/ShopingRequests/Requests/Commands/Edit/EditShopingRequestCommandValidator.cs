namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Edit
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;
    using static ShopingRequestSystem.Domain.Shared.ModelConstants.ShopingRequest;

    public class EditShopingRequestCommandValidator : AbstractValidator<EditShopingRequestCommand>
    {
        public EditShopingRequestCommandValidator(
            ICurrentUser currentUser,
            IRequesterDomainRepository requesterRepository)
        {
            this.Include(new ShopingRequestCommandValidator<EditShopingRequestCommand>(requesterRepository));

            this.RuleFor(c => c.RequestId)
                .MinimumLength(MinRequestIdLength)
                .MaximumLength(MaxRequestIdLength)
                .NotEmpty();

            this.RuleFor(c => c.RequesterId)
                .Must(requesterId => currentUser.UserId == requesterId)
                .WithMessage($"You cannot edit the shoping request.");
        }
    }
}
