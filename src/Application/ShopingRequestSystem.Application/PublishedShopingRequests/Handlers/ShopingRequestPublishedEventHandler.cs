namespace ShopingRequestSystem.Application.PublishedShopingRequests.Handlers
{
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Requests.Events;
    using ShopingRequestSystem.Domain.Requests.Models;

    public class ShopingRequestPublishedEventHandler : IEventHandler<ShopingRequestStatusChangeEvent>
    {
        public async Task Handle(ShopingRequestStatusChangeEvent domainEvent)
        {
            if (domainEvent.Status.Equals(RequestStatus.Published))
            {
                // TODO: Create published shoping request
            }
        }
    }
}
