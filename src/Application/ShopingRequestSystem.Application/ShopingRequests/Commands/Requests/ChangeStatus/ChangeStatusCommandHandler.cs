namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.ChangeStatus
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;

    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Result>
    {
        private readonly IShopingRequestDomainRepository shopingRequestRepository;

        public ChangeStatusCommandHandler(IShopingRequestDomainRepository shopingRequestRepository)
        {
            this.shopingRequestRepository = shopingRequestRepository;
        }

        public async Task<Result> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            ShopingRequest shopingRequest =
                await shopingRequestRepository.Find(request.Id, cancellationToken);

            shopingRequest.UpdateStatus(Enumeration.FromValue<RequestStatus>(request.NewStatus));

            await shopingRequestRepository.Save(shopingRequest, cancellationToken);

            return Result.Success;
        }
    }
}
