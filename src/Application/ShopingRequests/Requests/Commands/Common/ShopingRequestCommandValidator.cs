namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common
{
    using FluentValidation;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.Common;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.ShopingRequest;

    public class ShopingRequestCommandValidator<TCommand> : AbstractValidator<ShopingRequestCommand<TCommand>> 
        where TCommand : EntityCommand<int>
    {
        public ShopingRequestCommandValidator(IRequesterDomainRepository requesterRepository)
        {
            this.RuleFor(c => c.RequesterId)
                .MustAsync(async (requesterId, token) => await requesterRepository
                    .FindByUser(requesterId, token) != null)
                .WithMessage("The requester does not exist.");

            this.RuleFor(c => c.DeliveryAddress)
                .MinimumLength(MinAddressLength)
                .MaximumLength(MaxAddressLength)
                .NotEmpty();

            this.RuleFor(c => c.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength);

            this.RuleFor(c => c.PaymentSum)
                .InclusiveBetween(Zero, decimal.MaxValue);
        }
    }
}
