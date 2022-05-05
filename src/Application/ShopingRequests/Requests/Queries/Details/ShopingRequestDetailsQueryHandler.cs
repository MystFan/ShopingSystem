namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ShopingRequestDetailsQueryHandler 
        : IRequestHandler<ShopingRequestDetailsQuery<ShopingRequestDetailsOutputModel>, ShopingRequestDetailsOutputModel>
    {
        private readonly IShopingRequestQueryRepository shopingRequestRepository;

        public ShopingRequestDetailsQueryHandler(IShopingRequestQueryRepository shopingRequestRepository)
        {
            this.shopingRequestRepository = shopingRequestRepository;
        }

        public async Task<ShopingRequestDetailsOutputModel> Handle(
            ShopingRequestDetailsQuery<ShopingRequestDetailsOutputModel> request, 
            CancellationToken cancellationToken)
            => await this.shopingRequestRepository.GetDetails(request.Id, cancellationToken);
    }
}
