namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create
{
    public class CreateShopingRequestOutputModel
    {
        public CreateShopingRequestOutputModel(int requestId)
            => RequestId = requestId;

        public int RequestId { get; }
    }
}
