namespace ShopingRequestSystem.Domain.PublishedRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedRequests.Exceptions;
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
            ValidateProposedPrice(proposedPrice);

            Contractor = contractor;
            ProposedPrice = proposedPrice;
            IsBestOffer = isBestOffer;
        }

        private DeliveryOffer(decimal proposedPrice, bool isBestOffer)
        {
            Contractor = default!;
            ProposedPrice = proposedPrice;
            IsBestOffer = isBestOffer;
        }

        public Contractor Contractor { get; private set; }

        public decimal ProposedPrice { get; private set; }

        public bool IsBestOffer { get; private set; }

        public DeliveryOffer ChangeIsBestOffer()
        {
            IsBestOffer = !IsBestOffer;

            return this;
        }

        public DeliveryOffer UpdateProposedPrice(decimal proposedPrice)
        {
            ValidateProposedPrice(proposedPrice);
            ProposedPrice = proposedPrice;

            return this;
        }

        private void ValidateProposedPrice(decimal proposedPrice)
            => Guard.AgainstOutOfRange<InvalidDeliveryOfferException>(
                proposedPrice,
                Zero,
                decimal.MaxValue,
                nameof(ProposedPrice));
    }
}
