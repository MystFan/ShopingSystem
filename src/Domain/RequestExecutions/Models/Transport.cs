namespace ShopingRequestSystem.Domain.RequestExecutions.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.RequestExecutions.Exceptions;
    using static ModelConstants.Transport;

    public class Transport : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<TransportType> AllowedTransportTypes
            = new TransportTypeData().GetData().Cast<TransportType>();

        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal Transport()
        {
        }

        internal Transport(string name, TransportType transportType)
        {
            this.ValidateName(name);
            this.ValidateTransportType(transportType);

            this.Name = name;
            this.TransportType = transportType;
        }

        public string Name { get; private set; }

        public TransportType TransportType { get; private set; }

        public Transport UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public Transport UpdateTransportType(TransportType transportType)
        {
            this.ValidateTransportType(transportType);
            this.TransportType = transportType;

            return this;
        }

        private void ValidateTransportType(TransportType transportType)
        {
            var transportTypeName = transportType?.Name;

            if (AllowedTransportTypes.Any(c => c.Name == transportTypeName))
            {
                return;
            }

            var allowedTransportTypeNames = string.Join(", ", AllowedTransportTypes.Select(c => $"'{c.Name}'"));
            throw new InvalidTransportException($"'{transportTypeName}' is not a valid transport type. Allowed values are: {allowedTransportTypeNames}.");
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidTransportException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
