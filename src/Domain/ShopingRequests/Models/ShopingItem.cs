namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.Common;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.ShopingItem;

    public class ShopingItem : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal ShopingItem()
        {
        }

        internal ShopingItem(ShopingAddress address, string product, string unit, decimal quantity)
        {
            this.ValidateProduct(product);
            this.ValidateQuantity(quantity);
            this.ValidateUnit(unit);

            this.Product = product;
            this.Quantity = quantity;
            this.Unit = unit;
            this.Address = address;
        }

        private ShopingItem(string product, string unit, decimal quantity)
        {
            this.ValidateProduct(product);
            this.ValidateQuantity(quantity);
            this.ValidateUnit(unit);

            this.Product = product;
            this.Quantity = quantity;
            this.Unit = unit;
            this.Address = default!;
        }

        public string Product { get; private set; }

        public decimal Quantity { get; private set; }

        public string Unit { get; private set; }

        public ShopingAddress Address { get; private set; }

        public ShopingItem UpdateProduct(string product)
        {
            this.ValidateProduct(product);
            this.Product = product;

            return this;
        }

        public ShopingItem UpdateQuantity(decimal quantity)
        {
            this.ValidateQuantity(quantity);
            this.Quantity = quantity;

            return this;
        }

        public ShopingItem UpdateUnit(string unit)
        {
            this.ValidateUnit(unit);
            this.Unit = unit;

            return this;
        }

        private void ValidateProduct(string product)
            => Guard.ForStringLength<InvalidShopingItemException>(
                product,
                MinProductLength,
                MaxProductLength,
                nameof(this.Product));

        private void ValidateQuantity(decimal quantity)
            => Guard.AgainstOutOfRange<InvalidShopingItemException>(
                quantity,
                Zero,
                decimal.MaxValue,
                nameof(this.Quantity));

        private void ValidateUnit(string unit)
            => Guard.ForStringLength<InvalidShopingItemException>(
                unit,
                MinUnitLength,
                MaxUnitLength,
                nameof(this.Unit));
    }
}
