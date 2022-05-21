namespace ShopingRequestSystem.Infrastructure.ShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.Requests.Models;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Common;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.ShopingRequest;

    internal sealed class ShopingRequestDbConfiguration : IEntityTypeConfiguration<ShopingRequest>
    {
        public void Configure(EntityTypeBuilder<ShopingRequest> builder)
        {
            builder
                .HasKey(sr => sr.Id);

            builder
                .Property(sr => sr.RequestId)
                .IsRequired()
                .HasMaxLength(MaxRequestIdLength);

            builder
                .Property(sr => sr.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(sr => sr.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(sr => sr.DeliveryAddress)
                .IsRequired()
                .HasMaxLength(MaxAddressLength);

            builder
                .Property(sr => sr.PaymentSum)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .OwnsOne(
                    sr => sr.Status,
                    rs =>
                    {
                        rs.WithOwner();
                        rs.Property(s => s.Value);
                    });

            builder
                .HasOne(sr => sr.Requester)
                .WithMany()
                .HasForeignKey("RequesterId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(sr => sr.ShopingItems)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("shopingItems");
        }
    }
}
