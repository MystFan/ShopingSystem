namespace ShopingRequestSystem.Infrastructure.Identity
{
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    internal interface IIdentityDbContext : IDbContext
    {
        DbSet<User> Users { get; }
    }
}
