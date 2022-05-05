namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.ChangeStatus
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

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
                await this.shopingRequestRepository.Find(request.Id, cancellationToken);

            shopingRequest.UpdateStatus(Enumeration.FromValue<RequestStatus>(request.NewStatus));

            await this.shopingRequestRepository.Save(shopingRequest, cancellationToken);

            return Result.Success;
        }
    }
}
