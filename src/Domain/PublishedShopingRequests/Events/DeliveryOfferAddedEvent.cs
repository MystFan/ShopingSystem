namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Events
{
    using Common;

    public class DeliveryOfferAddedEvent : IDomainEvent
    {
        public DeliveryOfferAddedEvent(int shopingRequestId, decimal proposedPrice)
        {
            this.ShopingRequestId = shopingRequestId;
            this.ProposedPrice = proposedPrice;
        }

        public int ShopingRequestId { get; private set; }

        public decimal ProposedPrice { get; private set; }
    }
}
