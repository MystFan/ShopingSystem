namespace ShopingRequestSystem.Infrastructure.Identity.Configuration
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany<Requester>()
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany<Contractor>()
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
