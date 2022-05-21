namespace ShopingRequestSystem.Domain.Requests.Factories.Requests
{
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Exceptions;

    internal class ShopingRequestFactory : IShopingRequestFactory
    {
        private Requester requester = default!;
        private string shopingRequestId = default!;
        private string requestName = default!;
        private string requestDescription = default!;
        private string requestDeliveryAddress = default!;
        private decimal requestPaymentSum;
        private RequestStatus status = default!;

        private bool requesterSet = false;
        private bool statusSet = false;

        public IShopingRequestFactory WithRequestId(string requestId)
        {
            shopingRequestId = requestId;
            return this;
        }

        public IShopingRequestFactory WithRequester(Requester requester)
        {
            this.requester = requester;
            requesterSet = true;
            return this;
        }

        public IShopingRequestFactory WithName(string name)
        {
            requestName = name;
            return this;
        }

        public IShopingRequestFactory WithDescription(string description)
        {
            requestDescription = description;
            return this;
        }

        public IShopingRequestFactory WithDeliveryAddress(string requestDeliveryAddress)
        {
            this.requestDeliveryAddress = requestDeliveryAddress;
            return this;
        }

        public IShopingRequestFactory WithPaymentSum(decimal requestPaymentSum)
        {
            this.requestPaymentSum = requestPaymentSum;
            return this;
        }

        public IShopingRequestFactory WithStatus(RequestStatus status)
        {
            this.status = status;
            statusSet = true;
            return this;
        }

        public ShopingRequest Build()
        {
            if (!requesterSet || !statusSet)
            {
                throw new InvalidShopingRequestException("Requester and status must have a value.");
            }

            return new ShopingRequest(
                shopingRequestId,
                requester,
                status,
                requestName,
                requestDescription,
                requestDeliveryAddress,
                requestPaymentSum);
        }
    }
}
