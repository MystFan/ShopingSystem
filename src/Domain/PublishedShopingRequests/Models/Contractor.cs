namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions;
    using ShopingRequestSystem.Domain.Shared;
    using static ShopingRequestSystem.Domain.PublishedShopingRequests.Models.ModelConstants.Contractor;

    public class Contractor : Entity<int>, IAggregateRoot
    {
        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal Contractor()
        {
        }

        internal Contractor(string userId, string name, PhoneNumber phoneNumber)
        {
            this.ValidateName(name);

            this.UserId = userId;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        private Contractor(string userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
            this.PhoneNumber = default!;
        }

        public string UserId { get; private set; }

        public string Name { get; set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Contractor UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public Contractor UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidContractorException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
