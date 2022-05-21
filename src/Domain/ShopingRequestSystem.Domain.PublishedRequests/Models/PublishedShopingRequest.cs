namespace ShopingRequestSystem.Domain.PublishedRequests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedRequests.Events;

    public class PublishedShopingRequest : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<DeliveryOffer> deliveryOffers;

        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal PublishedShopingRequest()
        {
        }

        internal PublishedShopingRequest(int shopingRequesterId)
        {
            ShopingRequesterId = shopingRequesterId;

            deliveryOffers = new HashSet<DeliveryOffer>();
        }

        public int ShopingRequesterId { get; private set; }

        public IReadOnlyCollection<DeliveryOffer> DeliveryOffers => deliveryOffers.ToList().AsReadOnly();

        public void AddOffer(DeliveryOffer deliveryOffer)
        {
            deliveryOffers.Add(deliveryOffer);

            this.RaiseEvent(new DeliveryOfferAddedEvent(Id, deliveryOffer.ProposedPrice));
        }

        public DeliveryOffer GetBestOffer()
        {
            return deliveryOffers
                .OrderByDescending(o => o.ProposedPrice)
                .FirstOrDefault();
        }
    }
}
