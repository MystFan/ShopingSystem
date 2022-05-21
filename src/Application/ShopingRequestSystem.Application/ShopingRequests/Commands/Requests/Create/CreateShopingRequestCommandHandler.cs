namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.Requests.Factories.Requests;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;

    public class CreateShopingRequestCommandHandler : IRequestHandler<CreateShopingRequestCommand, CreateShopingRequestOutputModel>
    {
        private readonly ICurrentUser currentUser;
        private readonly IRequesterDomainRepository requesterRepository;
        private readonly IShopingRequestDomainRepository shopingRequestRepository;
        private readonly IShopingRequestFactory shopingRequestFactory;

        public CreateShopingRequestCommandHandler(
            ICurrentUser currentUser,
            IRequesterDomainRepository requesterRepository,
            IShopingRequestDomainRepository shopingRequestRepository,
            IShopingRequestFactory shopingRequestFactory)
        {
            this.currentUser = currentUser;
            this.requesterRepository = requesterRepository;
            this.shopingRequestRepository = shopingRequestRepository;
            this.shopingRequestFactory = shopingRequestFactory;
        }

        public async Task<CreateShopingRequestOutputModel> Handle(
            CreateShopingRequestCommand request,
            CancellationToken cancellationToken)
        {
            Requester requester = await requesterRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            ShopingRequest shopingRequest = shopingRequestFactory
                .WithRequestId(Guid.NewGuid().ToString())
                .WithRequester(requester)
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithDeliveryAddress(request.DeliveryAddress)
                .WithPaymentSum(request.PaymentSum)
                .WithStatus(RequestStatus.New)
                .Build();

            await shopingRequestRepository.Save(shopingRequest, cancellationToken);

            return new CreateShopingRequestOutputModel(shopingRequest.Id);
        }
    }
}
