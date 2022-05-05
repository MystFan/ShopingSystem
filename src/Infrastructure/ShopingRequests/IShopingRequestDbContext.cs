namespace ShopingRequestSystem.Infrastructure.ShopingRequests
{
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal interface IShopingRequestDbContext : IDbContext
    {
        DbSet<ShopingRequest> ShopingRequests { get; }

        DbSet<ShopingItem> ShopingItems { get; }

        DbSet<Requester> Requesters { get; }
    }
}
