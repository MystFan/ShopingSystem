namespace ShopingRequestSystem.Domain.Requests.Models
{
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Exceptions;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Common;

    public class ShopingAddress : ValueObject
    {
        internal ShopingAddress(string address)
        {
            ValidateAddress(address);

            Address = address;
        }

        public string Address { get; private set; }

        private void ValidateAddress(string address)
            => Guard.ForStringLength<InvalidShopingAddressException>(
                address,
                MinAddressLength,
                MaxAddressLength,
                nameof(Address));
    }
}
