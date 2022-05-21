namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;

    internal sealed class DeliveryOfferDbConfiguration : IEntityTypeConfiguration<DeliveryOffer>
    {
        public void Configure(EntityTypeBuilder<DeliveryOffer> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.ProposedPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(o => o.IsBestOffer)
                .IsRequired();

            builder
                .HasOne(o => o.Contractor)
                .WithMany()
                .HasForeignKey("ContractorId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
