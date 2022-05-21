namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create
{
    using FluentValidation;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Common;
    using ShopingRequestSystem.Domain.Requests.Repositories;

    public class CreateShopingRequestCommandValidator : AbstractValidator<CreateShopingRequestCommand>
    {
        public CreateShopingRequestCommandValidator(IRequesterDomainRepository requesterRepository)
            => Include(new ShopingRequestCommandValidator<CreateShopingRequestCommand>(requesterRepository));
    }
}
