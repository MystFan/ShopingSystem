namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Create
{
    using FluentValidation;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

    public class CreateShopingRequestCommandValidator : AbstractValidator<CreateShopingRequestCommand>
    {
        public CreateShopingRequestCommandValidator(IRequesterDomainRepository requesterRepository) 
            => this.Include(new ShopingRequestCommandValidator<CreateShopingRequestCommand>(requesterRepository));
    }
}
