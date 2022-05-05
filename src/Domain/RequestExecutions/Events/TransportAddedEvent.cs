namespace ShopingRequestSystem.Domain.RequestExecutions.Events
{
    using ShopingRequestSystem.Domain.Common;

    public class TransportAddedEvent : IDomainEvent
    {
        public TransportAddedEvent(int requestExecutionId, int transportId)
        {
            this.RequestExecutionId = requestExecutionId;
            this.TransportId = transportId;
        }

        public int RequestExecutionId { get; private set; }

        public int TransportId { get; private set; }
    }
}
