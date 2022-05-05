namespace ShopingRequestSystem.Application.PublishedShopingRequests.Handlers
{
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Events;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

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
