namespace ShopingRequestSystem.Domain.PublishedRequests.Events
{
    using ShopingRequestSystem.Domain.Common;

    public class DeliveryOfferAddedEvent : IDomainEvent
    {
        public DeliveryOfferAddedEvent(int shopingRequestId, decimal proposedPrice)
        {
            ShopingRequestId = shopingRequestId;
            ProposedPrice = proposedPrice;
        }

        public int ShopingRequestId { get; private set; }

        public decimal ProposedPrice { get; private set; }
    }
}
