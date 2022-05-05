namespace ShopingRequestSystem.Domain.ShopingRequests.Factories.Requests
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public interface IShopingRequestFactory : IFactory<ShopingRequest>
    {
        IShopingRequestFactory WithRequestId(string requestId);

        IShopingRequestFactory WithRequester(Requester requester);

        IShopingRequestFactory WithName(string name);

        IShopingRequestFactory WithDescription(string description);

        IShopingRequestFactory WithDeliveryAddress(string deliveryAddress);

        IShopingRequestFactory WithPaymentSum(decimal paymentSum);

        IShopingRequestFactory WithStatus(RequestStatus status);
    }
}
