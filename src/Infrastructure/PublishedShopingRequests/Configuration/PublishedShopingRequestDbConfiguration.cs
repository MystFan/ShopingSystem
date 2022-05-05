namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    internal sealed class PublishedShopingRequestDbConfiguration : IEntityTypeConfiguration<PublishedShopingRequest>
    {
        public void Configure(EntityTypeBuilder<PublishedShopingRequest> builder)
        {
            builder
                .HasOne<ShopingRequest>()
                .WithOne()
                .HasForeignKey<PublishedShopingRequest>("ShopingRequesterId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(psr => psr.DeliveryOffers)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("deliveryOffers");
        }
    }
}
