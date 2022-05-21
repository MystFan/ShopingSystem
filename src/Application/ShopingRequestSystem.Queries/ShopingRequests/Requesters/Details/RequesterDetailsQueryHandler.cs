namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequesterDetailsQueryHandler : IRequestHandler<RequesterDetailsQuery<RequesterDetailsModel>, RequesterDetailsModel>
    {
        private readonly IRequesterQueryRepository requesterRepository;

        public RequesterDetailsQueryHandler(IRequesterQueryRepository requesterRepository)
            => this.requesterRepository = requesterRepository;

        public async Task<RequesterDetailsModel> Handle(
            RequesterDetailsQuery<RequesterDetailsModel> request,
            CancellationToken cancellationToken)
            => await requesterRepository.GetDeatailsAsync(request.Id, cancellationToken);
    }
}
