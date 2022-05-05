namespace ShopingRequestSystem.Domain.ShopingRequests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    internal class RequesterFactory : IRequesterFactory
    {
        private string requesterUserId = default!;
        private string requesterName = default!;
        private string requesterPhoneNumber = default!;

        public IRequesterFactory WithUserId(string userId)
        {
            this.requesterUserId = userId;
            return this;
        }

        public IRequesterFactory WithName(string name)
        {
            this.requesterName = name;
            return this;
        }

        public IRequesterFactory WithPhoneNumber(string phoneNumber)
        {
            this.requesterPhoneNumber = phoneNumber;
            return this;
        }

        public Requester Build() => new Requester(this.requesterUserId, this.requesterName, this.requesterPhoneNumber);
    }
}
