namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Edit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

    public class EditShopingRequestCommandHandler : IRequestHandler<EditShopingRequestCommand, Result>
    {
        private readonly IShopingRequestDomainRepository shopingRequestRepository;

        public EditShopingRequestCommandHandler(
            IShopingRequestDomainRepository shopingRequestRepository)
        {
            this.shopingRequestRepository = shopingRequestRepository;
        }

        public async Task<Result> Handle(
            EditShopingRequestCommand request,
            CancellationToken cancellationToken)
        {
            ShopingRequest shopingRequest
                = await this.shopingRequestRepository.Find(request.Id, cancellationToken);

            List<string> errors = new List<string>();
            if (shopingRequest.Requester.UserId != request.RequesterId)
            {
                errors.Add($"{shopingRequest.Requester.Name} is not the request creator");
            }

            if (!shopingRequest.Status.Equals(RequestStatus.New))
            {
                errors.Add($"Can edit request only in status 'New'.");
            }

            Result result = errors.Any() ? Result.Failure(errors) : Result.Success;
            if (!result)
            {
                return result;
            }

            shopingRequest
                .UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdatePaymentSum(request.PaymentSum)
                .UpdateAddress(request.DeliveryAddress);

            await this.shopingRequestRepository.Save(shopingRequest, cancellationToken);

            return Result.Success;
        }
    }
}
