namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequesterDetailsQueryHandler : IRequestHandler<RequesterDetailsQuery<RequesterDetailsModel>, RequesterDetailsModel>
    {
        private readonly IRequesterDataSource requesterDataSource;

        public RequesterDetailsQueryHandler(IRequesterDataSource requesterDataSource)
            => this.requesterDataSource = requesterDataSource;

        public async Task<RequesterDetailsModel> Handle(
            RequesterDetailsQuery<RequesterDetailsModel> request,
            CancellationToken cancellationToken)
            => await requesterDataSource.GetDeatailsAsync(request.Id, cancellationToken);
    }
}
