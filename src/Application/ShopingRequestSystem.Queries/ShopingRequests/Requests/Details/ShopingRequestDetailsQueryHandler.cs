namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters;

    internal class ShopingRequestDetailsQueryHandler : IRequestHandler<ShopingRequestDetailsQuery<ShopingRequestDetailsModel>, ShopingRequestDetailsModel>
    {
        private readonly ShopingRequestDataSource requestDataSource;
        private readonly RequesterDataSource requesterDataSource;

        public ShopingRequestDetailsQueryHandler(
            ShopingRequestDataSource requestDataSource,
            RequesterDataSource requesterDataSource)
        {
            this.requestDataSource = requestDataSource;
            this.requesterDataSource = requesterDataSource;
        }

        public async Task<ShopingRequestDetailsModel> Handle(ShopingRequestDetailsQuery<ShopingRequestDetailsModel> request, CancellationToken cancellationToken)
        {
            ShopingRequestDetailsModel shopingRequest =
                await this.requestDataSource.GetDetailsAsync(request.Id, cancellationToken);

            if (shopingRequest != null)
            {
                shopingRequest.Requester = await this.requesterDataSource.GetDeatailsAsync(shopingRequest.RequesterId, cancellationToken);
            }

            return shopingRequest;
        }
    }
}
