namespace ShopingRequestSystem.Domain.PublishedRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedRequests.Exceptions;
    using static ShopingRequestSystem.Domain.PublishedRequests.Models.ModelConstants.Contractor;

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
            ValidateName(name);

            UserId = userId;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        private Contractor(string userId, string name)
        {
            UserId = userId;
            Name = name;
            PhoneNumber = default!;
        }

        public string UserId { get; private set; }

        public string Name { get; set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Contractor UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            return this;
        }

        public Contractor UpdateName(string name)
        {
            ValidateName(name);
            Name = name;

            return this;
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidContractorException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));
    }
}
