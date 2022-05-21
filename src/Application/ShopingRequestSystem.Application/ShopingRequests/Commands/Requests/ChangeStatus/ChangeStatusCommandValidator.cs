namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.ChangeStatus
{
    using System.Linq;
    using FluentValidation;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Models;

    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(c => c.NewStatus)
                .Must(value => Enumeration.GetAll<RequestStatus>().Select(v => v.Value).Contains(value))
                .WithMessage($"Status is not valid.");
        }
    }
}
