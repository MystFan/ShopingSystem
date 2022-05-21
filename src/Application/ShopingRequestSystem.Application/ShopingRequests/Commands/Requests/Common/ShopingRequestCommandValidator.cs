namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Common
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Requests.Repositories;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Common;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.ShopingRequest;

    public class ShopingRequestCommandValidator<TCommand> : AbstractValidator<ShopingRequestCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ShopingRequestCommandValidator(IRequesterDomainRepository requesterRepository)
        {
            RuleFor(c => c.RequesterId)
                .MustAsync(async (requesterId, token) => await requesterRepository
                    .FindByUser(requesterId, token) != null)
                .WithMessage("The requester does not exist.");

            RuleFor(c => c.DeliveryAddress)
                .MinimumLength(MinAddressLength)
                .MaximumLength(MaxAddressLength)
                .NotEmpty();

            RuleFor(c => c.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            RuleFor(c => c.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength);

            RuleFor(c => c.PaymentSum)
                .InclusiveBetween(Zero, decimal.MaxValue);
        }
    }
}
