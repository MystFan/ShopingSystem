namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Create
{
    public class CreateShopingRequestOutputModel
    {
        public CreateShopingRequestOutputModel(int requestId) 
            => this.RequestId = requestId;

        public int RequestId { get; }
    }
}
