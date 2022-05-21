namespace ShopingRequestSystem.Domain.Requests.Factories.Requests
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Requests.Models;

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
