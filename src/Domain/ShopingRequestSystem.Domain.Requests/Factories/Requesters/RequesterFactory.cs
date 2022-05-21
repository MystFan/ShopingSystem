namespace ShopingRequestSystem.Domain.Requests.Factories.Requesters
{
    using ShopingRequestSystem.Domain.Requests.Models;

    internal class RequesterFactory : IRequesterFactory
    {
        private string requesterUserId = default!;
        private string requesterName = default!;
        private string requesterPhoneNumber = default!;

        public IRequesterFactory WithUserId(string userId)
        {
            requesterUserId = userId;
            return this;
        }

        public IRequesterFactory WithName(string name)
        {
            requesterName = name;
            return this;
        }

        public IRequesterFactory WithPhoneNumber(string phoneNumber)
        {
            requesterPhoneNumber = phoneNumber;
            return this;
        }

        public Requester Build() => new Requester(requesterUserId, requesterName, requesterPhoneNumber);
    }
}
