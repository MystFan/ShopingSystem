namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions;
    using static ModelConstants.Common;

    public class DeliveryOffer : Entity<int>, IAggregateRoot
    {
        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal DeliveryOffer()
        {
        }

        internal DeliveryOffer(Contractor contractor, decimal proposedPrice, bool isBestOffer)
        {
            this.ValidateProposedPrice(proposedPrice);

            this.Contractor = contractor;
            this.ProposedPrice = proposedPrice;
            this.IsBestOffer = isBestOffer;
        }

        private DeliveryOffer(decimal proposedPrice, bool isBestOffer)
        {
            this.Contractor = default!;
            this.ProposedPrice = proposedPrice;
            this.IsBestOffer = isBestOffer;
        }

        public Contractor Contractor { get; private set; }

        public decimal ProposedPrice { get; private set; }

        public bool IsBestOffer { get; private set; }

        public DeliveryOffer ChangeIsBestOffer()
        {
            this.IsBestOffer = !this.IsBestOffer;

            return this;
        }

        public DeliveryOffer UpdateProposedPrice(decimal proposedPrice)
        {
            this.ValidateProposedPrice(proposedPrice);
            this.ProposedPrice = proposedPrice;

            return this;
        }

        private void ValidateProposedPrice(decimal proposedPrice)
            => Guard.AgainstOutOfRange<InvalidDeliveryOfferException>(
                proposedPrice,
                Zero,
                decimal.MaxValue,
                nameof(this.ProposedPrice));
    }
}
