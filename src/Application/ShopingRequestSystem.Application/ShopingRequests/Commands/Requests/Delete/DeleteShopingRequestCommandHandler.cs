namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.Requests.Repositories;

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
            bool userHasShopingRequest = await shopingRequestRepository
                .RequesterHasShopingRequest(
                    currentUser.UserId,
                    request.Id,
                    cancellationToken);

            if (!userHasShopingRequest)
            {
                return userHasShopingRequest;
            }

            return await shopingRequestRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
