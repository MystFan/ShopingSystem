namespace ShopingRequestSystem.Domain.Requests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Exceptions;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Common;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.ShopingItem;

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
            ValidateProduct(product);
            ValidateQuantity(quantity);
            ValidateUnit(unit);

            Product = product;
            Quantity = quantity;
            Unit = unit;
            Address = address;
        }

        private ShopingItem(string product, string unit, decimal quantity)
        {
            ValidateProduct(product);
            ValidateQuantity(quantity);
            ValidateUnit(unit);

            Product = product;
            Quantity = quantity;
            Unit = unit;
            Address = default!;
        }

        public string Product { get; private set; }

        public decimal Quantity { get; private set; }

        public string Unit { get; private set; }

        public ShopingAddress Address { get; private set; }

        public ShopingItem UpdateProduct(string product)
        {
            ValidateProduct(product);
            Product = product;

            return this;
        }

        public ShopingItem UpdateQuantity(decimal quantity)
        {
            ValidateQuantity(quantity);
            Quantity = quantity;

            return this;
        }

        public ShopingItem UpdateUnit(string unit)
        {
            ValidateUnit(unit);
            Unit = unit;

            return this;
        }

        private void ValidateProduct(string product)
            => Guard.ForStringLength<InvalidShopingItemException>(
                product,
                MinProductLength,
                MaxProductLength,
                nameof(Product));

        private void ValidateQuantity(decimal quantity)
            => Guard.AgainstOutOfRange<InvalidShopingItemException>(
                quantity,
                Zero,
                decimal.MaxValue,
                nameof(Quantity));

        private void ValidateUnit(string unit)
            => Guard.ForStringLength<InvalidShopingItemException>(
                unit,
                MinUnitLength,
                MaxUnitLength,
                nameof(Unit));
    }
}
