namespace ShopingRequestSystem.Domain.RequestExecutions.Models
{
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.RequestExecutions.Exceptions;
    using static ModelConstants.TransportType;

    public class TransportType : Entity<int>
    {
        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal TransportType()
        {
        }

        internal TransportType(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidTransportTypeException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidTransportTypeException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
