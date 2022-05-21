namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Edit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;

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
                = await shopingRequestRepository.Find(request.Id, cancellationToken);

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

            await shopingRequestRepository.Save(shopingRequest, cancellationToken);

            return Result.Success;
        }
    }
}
