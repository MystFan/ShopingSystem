namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;

    internal class ContractorFactory : IContractorFactory
    {
        private string contractorUserId = default!;
        private string contractorName = default!;
        private string contractorPhoneNumber = default!;

        public IContractorFactory WithUserId(string userId)
        {
            this.contractorUserId = userId;
            return this;
        }

        public IContractorFactory WithName(string name)
        {
            this.contractorName = name;
            return this;
        }

        public IContractorFactory WithPhoneNumber(string phoneNumber)
        {
            this.contractorPhoneNumber = phoneNumber;
            return this;
        }

        public Contractor Build() => new Contractor(this.contractorUserId, this.contractorName, this.contractorPhoneNumber);
    }
}
