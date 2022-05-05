namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class RequesterDetailsQueryHandler : IRequestHandler<RequesterDetailsQuery, RequesterDetailsOutputModel>
    {
        private readonly IRequesterQueryRepository requesterRepository;

        public RequesterDetailsQueryHandler(IRequesterQueryRepository requesterRepository)
            => this.requesterRepository = requesterRepository;

        public async Task<RequesterDetailsOutputModel> Handle(
            RequesterDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.requesterRepository.GetDetails(request.Id, cancellationToken);
    }
}
