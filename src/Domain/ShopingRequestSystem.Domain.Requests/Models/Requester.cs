namespace ShopingRequestSystem.Domain.Requests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.Requests.Exceptions;
    using ShopingRequestSystem.Domain.Shared;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Requester;

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
            ValidateName(name);

            UserId = userId;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        private Requester(string userId, string name)
        {
            ValidateName(name);

            UserId = userId;
            Name = name;
            PhoneNumber = default!;
        }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Requester UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            return this;
        }

        public Requester UpdateName(string name)
        {
            ValidateName(name);

            Name = name;

            return this;
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidRequesterException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));
    }
}
