namespace ShopingRequestSystem.Domain.Requests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Events;
    using ShopingRequestSystem.Domain.Requests.Exceptions;
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
            ValidateRequestId(requestId);
            ValidateName(name);
            ValidateDescription(description);
            ValidateAddress(deliveryAddress);
            ValidatePaymentSum(paymentSum);
            ValidateRequestStatus(status);

            RequestId = requestId;
            Requester = requester;
            Status = status;
            Name = name;
            Description = description;
            DeliveryAddress = deliveryAddress;
            PaymentSum = paymentSum;

            shopingItems = new HashSet<ShopingItem>();
        }

        private ShopingRequest(string requestId, string name, string description, string deliveryAddress, decimal paymentAmount)
        {
            RequestId = requestId;
            Name = name;
            Description = description;
            DeliveryAddress = deliveryAddress;
            PaymentSum = paymentAmount;

            Requester = default!;
            Status = default!;
            shopingItems = new HashSet<ShopingItem>();
        }

        public string RequestId { get; private set; }

        public Requester Requester { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DeliveryAddress { get; private set; }

        public decimal PaymentSum { get; private set; }

        public RequestStatus Status { get; private set; }

        public IReadOnlyCollection<ShopingItem> ShopingItems => shopingItems.ToList().AsReadOnly();

        public void AddShopingItem(ShopingItem shopingItem)
        {
            shopingItems.Add(shopingItem);
        }

        public ShopingRequest UpdateName(string name)
        {
            ValidateName(name);
            Name = name;

            return this;
        }

        public ShopingRequest UpdateDescription(string description)
        {
            ValidateDescription(description);
            Description = description;

            return this;
        }

        public ShopingRequest UpdateAddress(string address)
        {
            ValidateAddress(address);
            DeliveryAddress = address;

            return this;
        }

        public ShopingRequest UpdatePaymentSum(decimal paymentSum)
        {
            ValidatePaymentSum(paymentSum);
            PaymentSum = paymentSum;

            return this;
        }

        public ShopingRequest UpdateStatus(RequestStatus status)
        {
            ValidateRequestStatus(status);
            Status = status;

            this.RaiseEvent(new ShopingRequestStatusChangeEvent(this.Id, status));
            return this;
        }

        private void ValidateRequestId(string requestId)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                requestId,
                MinRequestIdLength,
                MaxRequestIdLength,
                nameof(RequestId));

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(Description));

        private void ValidateAddress(string deliveryAddress)
            => Guard.ForStringLength<InvalidShopingRequestException>(
                deliveryAddress,
                MinAddressLength,
                MaxAddressLength,
                nameof(DeliveryAddress));

        private void ValidatePaymentSum(decimal paymentSum)
            => Guard.AgainstOutOfRange<InvalidShopingRequestException>(
                paymentSum,
                Zero,
                decimal.MaxValue,
                nameof(PaymentSum));

        private void ValidateRequestStatus(RequestStatus status)
            => RequestStatusGuard.ForValidStatus<InvalidShopingRequestException>(
                status,
                Status,
                nameof(Status));
    }
}
