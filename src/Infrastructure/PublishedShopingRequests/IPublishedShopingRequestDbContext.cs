namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests
{
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal interface IPublishedShopingRequestDbContext : IDbContext
    {
        DbSet<PublishedShopingRequest> PublishedShopingRequests { get; }

        DbSet<Contractor> Contractors { get; }

        DbSet<DeliveryOffer> DeliveryOffers { get; }
    }
}
