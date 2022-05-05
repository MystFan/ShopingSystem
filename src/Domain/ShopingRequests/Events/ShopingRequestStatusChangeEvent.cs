namespace ShopingRequestSystem.Domain.ShopingRequests.Events
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestStatusChangeEvent : IDomainEvent
    {
        public ShopingRequestStatusChangeEvent(int shopingRequestId, RequestStatus status)
        {
            this.ShopingRequestId = shopingRequestId;
            this.Status = status;
        }

        public int ShopingRequestId { get; private set; }

        public RequestStatus Status { get; private set; }
    }
}
