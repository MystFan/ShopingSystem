namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Events;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using static Shared.ModelConstants.ShopingRequest;
    using static ModelConstants.Common;
    using static ModelConstants.ShopingRequest;

    public class ShopingRequest : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<ShopingItem> shopingItems;

        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal ShopingRequest()
        {
        }

        internal ShopingRequest(
            string requestId,
            Requester requester, 
            RequestStatus status,
            string name,
            string description, 
            string deliveryAddress,
            decimal paymentSum)
        {
            this.ValidateRequestId(requestId);
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidateAddress(deliveryAddress);
            this.ValidatePaymentSum(paymentSum);
            this.ValidateRequestStatus(status);

            this.RequestId = requestId;
            this.Requester = requester;
            this.Status = status;
            this.Name = name;
            this.Description = description;
            this.DeliveryAddress = deliveryAddress;
            this.PaymentSum = paymentSum;

            this.shopingItems = new HashSet<ShopingItem>();
        }

        private ShopingRequest(string requestId, string name, string description, string deliveryAddress, decimal paymentAmount)
        {
            this.RequestId = requestId;
            this.Name = name;
            this.Description = description;
            this.DeliveryAddress = deliveryAddress;
            this.PaymentSum = paymentAmount;

            this.Requester = default!;
            this.Status = default!;
            this.shopingItems = new HashSet<ShopingItem>();
        }

        public string RequestId { get; private set; }

        public Requester Requester { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DeliveryAddress { get; private set; }

        public decimal PaymentSum { get; private set; }

        public RequestStatus Status { get; private set; }

        public IReadOnlyCollection<ShopingItem> ShopingItems => this.shopingItems.ToList().AsReadOnly();

        public void AddShopingItem(ShopingItem shopingItem)
        {
            this.shopingItems.Add(shopingItem);
        }

        public ShopingRequest UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public ShopingRequest UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public ShopingRequest UpdateAddress(string address)
        {
            this.ValidateAddress(address);
            this.DeliveryAddress = address;

            return this;
        }

        public ShopingRequest UpdatePaymentSum(decimal paymentSum)
        {
            this.ValidatePaymentSum(paymentSum);
            this.PaymentSum = paymentSum;

            return this;
        }

        public ShopingRequest UpdateStatus(RequestStatus status)
        {
            this.ValidateRequestStatus(status);
            this.Status = status;

            this.RaiseEvent(new ShopingRequestStatusChangeEvent(this.Id, status));
            return this;
        }

        private void ValidateRequestId(string requestId)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                requestId,
                MinRequestIdLength,
                MaxRequestIdLength,
                nameof(this.RequestId));

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

        private void ValidateAddress(string deliveryAddress)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                deliveryAddress,
                MinAddressLength,
                MaxAddressLength,
                nameof(this.DeliveryAddress));

        private void ValidatePaymentSum(decimal paymentSum)
            => Guard.AgainstOutOfRange<InvalidShopingRequestException>(
                paymentSum,
                Zero,
                decimal.MaxValue,
                nameof(this.PaymentSum));

        private void ValidateRequestStatus(RequestStatus status)
            => RequestStatusGuard.ForValidStatus<InvalidShopingRequestException>(
                status,
                this.Status,
                nameof(this.Status));
    }
}
