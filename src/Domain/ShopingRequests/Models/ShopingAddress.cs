namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.Common;

    public class ShopingAddress : ValueObject
    {
        internal ShopingAddress(string address)
        {
            this.ValidateAddress(address);

            this.Address = address;
        }

        public string Address { get; private set; }

        private void ValidateAddress(string address)
            => Guard.ForStringLength<InvalidShopingAddressException>(
                address,
                MinAddressLength,
                MaxAddressLength,
                nameof(this.Address));
    }
}
