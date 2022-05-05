namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Details
{
    using MediatR;

    public class RequesterDetailsQuery : IRequest<RequesterDetailsOutputModel>
    {
        public int Id { get; set; }
    }
}
