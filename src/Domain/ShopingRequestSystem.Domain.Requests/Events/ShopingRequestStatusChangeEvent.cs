namespace ShopingRequestSystem.Domain.Requests.Events
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Requests.Models;

    public class ShopingRequestStatusChangeEvent : IDomainEvent
    {
        public ShopingRequestStatusChangeEvent(int shopingRequestId, RequestStatus status)
        {
            ShopingRequestId = shopingRequestId;
            Status = status;
        }

        public int ShopingRequestId { get; private set; }

        public RequestStatus Status { get; private set; }
    }
}
