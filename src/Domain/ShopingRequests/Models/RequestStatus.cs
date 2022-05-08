namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common.Models;

    public class RequestStatus : Enumeration
    {
        public static readonly RequestStatus Open = new RequestStatus(1, nameof(Open));
        public static readonly RequestStatus Published = new RequestStatus(2, nameof(Published));
        public static readonly RequestStatus InProgress = new RequestStatus(3, nameof(InProgress));
        public static readonly RequestStatus Completed = new RequestStatus(4, nameof(Completed));
        public static readonly RequestStatus Closed = new RequestStatus(5, nameof(Closed));

        private RequestStatus(int value)
            : this(value, FromValue<RequestStatus>(value).Name)
        {
        }

        private RequestStatus(int value, string name)
            : base(value, name)
        {
        }
    }
}
