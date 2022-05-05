namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Shared;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.Requester;

    public class Requester : Entity<int>, IAggregateRoot
    {
        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal Requester()
        {
        }

        internal Requester(string userId, string name, PhoneNumber phoneNumber)
        {
            this.ValidateName(name);

            this.UserId = userId;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        private Requester(string userId, string name)
        {
            this.ValidateName(name);

            this.UserId = userId;
            this.Name = name;
            this.PhoneNumber = default!;
        }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Requester UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public Requester UpdateName(string name)
        {
            this.ValidateName(name);

            this.Name = name;

            return this;
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidRequesterException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
