namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.ChangeStatus
{
    using System.Linq;
    using FluentValidation;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            this.RuleFor(c => c.NewStatus)
                .Must(value => Enumeration.GetAll<RequestStatus>().Select(v => v.Value).Contains(value))
                .WithMessage($"Status is not valid.");
        }
    }
}
