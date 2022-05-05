namespace ShopingRequestSystem.Domain.RequestExecutions.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.RequestExecutions.Events;
    using ShopingRequestSystem.Domain.RequestExecutions.Exceptions;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.RequestExecution;
    using static Shared.ModelConstants.ShopingRequest;

    public class RequestExecution : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Transport> transports;

        /// <summary>
        /// Required for entity framework
        /// </summary>
        internal RequestExecution()
        {
        }

        internal RequestExecution(
            string requestId, 
            string contractorId,
            decimal paidSum,
            string notes)
        {
            this.ValidateRequestId(requestId);
            this.ValidatePaidSum(paidSum);
            this.ValidateNotes(notes);

            this.RequestId = requestId;
            this.ContractorId = contractorId;
            this.PaidSum = paidSum;
            this.Notes = notes;

            this.transports = new HashSet<Transport>();
        }

        public string RequestId { get; private set; }

        public string ContractorId { get; private set; }

        public string Notes { get; private set; }

        public decimal PaidSum { get; private set; }

        public IReadOnlyCollection<Transport> Transports => this.transports.ToList().AsReadOnly();

        public void AddTransport(Transport transport)
        {
            this.transports.Add(transport);

            this.RaiseEvent(new TransportAddedEvent(this.Id, transport.Id));
        }

        public RequestExecution UpdateNotes(string notes)
        {
            this.ValidateNotes(notes);
            this.Notes = notes;

            return this;
        }

        public RequestExecution UpdateRequestId(string requestId)
        {
            this.ValidateRequestId(requestId);
            this.RequestId = requestId;

            return this;
        }

        public RequestExecution UpdatePaidSum(decimal paidSum)
        {
            this.ValidatePaidSum(paidSum);
            this.PaidSum = paidSum;

            return this;
        }

        private void ValidateRequestId(string requestId)
            => Guard.ForStringLength<InvalidRequestExecutionException>(
                requestId,
                MinRequestIdLength,
                MaxRequestIdLength,
                nameof(this.RequestId));

        private void ValidatePaidSum(decimal paidSum)
            => Guard.AgainstOutOfRange<InvalidShopingRequestException>(
                paidSum,
                Zero,
                decimal.MaxValue,
                nameof(this.PaidSum));

        private void ValidateNotes(string notes)
            => Guard.ForStringLength<InvalidRequestExecutionException>(
                notes,
                MaxNotesLength,
                nameof(this.Notes));
    }
}
