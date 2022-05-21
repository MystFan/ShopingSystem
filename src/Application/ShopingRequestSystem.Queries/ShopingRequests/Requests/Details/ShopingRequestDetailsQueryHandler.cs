namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters;

    internal class ShopingRequestDetailsQueryHandler : IRequestHandler<ShopingRequestDetailsQuery<ShopingRequestDetailsModel>, ShopingRequestDetailsModel>
    {
        private readonly ShopingRequestQueryRepository repository;
        private readonly RequesterQueryRepository requesterQueryRepository;

        public ShopingRequestDetailsQueryHandler(
            ShopingRequestQueryRepository repository,
            RequesterQueryRepository requesterQueryRepository)
        {
            this.repository = repository;
            this.requesterQueryRepository = requesterQueryRepository;
        }

        public async Task<ShopingRequestDetailsModel> Handle(ShopingRequestDetailsQuery<ShopingRequestDetailsModel> request, CancellationToken cancellationToken)
        {
            ShopingRequestDetailsModel shopingRequest =
                await this.repository.GetDetailsAsync(request.Id, cancellationToken);

            if (shopingRequest != null)
            {
                shopingRequest.Requester = await this.requesterQueryRepository.GetDeatailsAsync(shopingRequest.RequesterId, cancellationToken);
            }

            return shopingRequest;
        }
    }
}
