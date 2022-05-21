namespace ShopingRequestSystem.Domain.PublishedRequests.Factories.Contractors
{
    using ShopingRequestSystem.Domain.PublishedRequests.Models;

    internal class ContractorFactory : IContractorFactory
    {
        private string contractorUserId = default!;
        private string contractorName = default!;
        private string contractorPhoneNumber = default!;

        public IContractorFactory WithUserId(string userId)
        {
            contractorUserId = userId;
            return this;
        }

        public IContractorFactory WithName(string name)
        {
            contractorName = name;
            return this;
        }

        public IContractorFactory WithPhoneNumber(string phoneNumber)
        {
            contractorPhoneNumber = phoneNumber;
            return this;
        }

        public Contractor Build() => new Contractor(contractorUserId, contractorName, contractorPhoneNumber);
    }
}
