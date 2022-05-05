namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Events;

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
            this.ShopingRequesterId = shopingRequesterId;

            this.deliveryOffers = new HashSet<DeliveryOffer>();
        }

        public int ShopingRequesterId { get; private set; }

        public IReadOnlyCollection<DeliveryOffer> DeliveryOffers => this.deliveryOffers.ToList().AsReadOnly();

        public void AddOffer(DeliveryOffer deliveryOffer)
        {
            this.deliveryOffers.Add(deliveryOffer);

            this.RaiseEvent(new DeliveryOfferAddedEvent(this.Id, deliveryOffer.ProposedPrice));
        }

        public DeliveryOffer GetBestOffer()
        {
            return this.deliveryOffers
                .OrderByDescending(o => o.ProposedPrice)
                .FirstOrDefault();
        }
    }
}
