namespace ShopingRequestSystem.Domain.ShopingRequests.Factories.Requests
{
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

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
            this.shopingRequestId = requestId;
            return this;
        }

        public IShopingRequestFactory WithRequester(Requester requester)
        {
            this.requester = requester;
            this.requesterSet = true;
            return this;
        }

        public IShopingRequestFactory WithName(string name)
        {
            this.requestName = name;
            return this;
        }

        public IShopingRequestFactory WithDescription(string description)
        {
            this.requestDescription = description;
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
            this.statusSet = true;
            return this;
        }

        public ShopingRequest Build()
        {
            if (!this.requesterSet || !this.statusSet)
            {
                throw new InvalidShopingRequestException("Requester and status must have a value.");
            }

            return new ShopingRequest(
                this.shopingRequestId,
                this.requester,
                this.status,
                this.requestName,
                this.requestDescription,
                this.requestDeliveryAddress,
                this.requestPaymentSum);
        }
    }
}
