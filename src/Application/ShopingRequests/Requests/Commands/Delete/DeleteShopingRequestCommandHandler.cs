namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

    public class DeleteShopingRequestCommandHandler : IRequestHandler<DeleteShopingRequestCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IShopingRequestDomainRepository shopingRequestRepository;

        public DeleteShopingRequestCommandHandler(
            ICurrentUser currentUser,
            IShopingRequestDomainRepository shopingRequestRepository)
        {
            this.currentUser = currentUser;
            this.shopingRequestRepository = shopingRequestRepository;
        }

        public async Task<Result> Handle(
            DeleteShopingRequestCommand request,
            CancellationToken cancellationToken)
        {
            bool userHasShopingRequest = await this.shopingRequestRepository
                .RequesterHasShopingRequest(
                    this.currentUser.UserId,
                    request.Id,
                    cancellationToken);

            if (!userHasShopingRequest)
            {
                return userHasShopingRequest;
            }

            return await this.shopingRequestRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
