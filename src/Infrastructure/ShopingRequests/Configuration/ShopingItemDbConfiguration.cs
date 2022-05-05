namespace ShopingRequestSystem.Infrastructure.ShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using static ShopingRequestSystem.Domain.ShopingRequests.Models.ModelConstants.ShopingItem;

    internal sealed class ShopingItemDbConfiguration : IEntityTypeConfiguration<ShopingItem>
    {
        public void Configure(EntityTypeBuilder<ShopingItem> builder)
        {
            builder
                .HasKey(si => si.Id);

            builder
                .Property(si => si.Product)
                .IsRequired()
                .HasMaxLength(MaxProductLength);

            builder
                .Property(si => si.Unit)
                .IsRequired()
                .HasMaxLength(MaxUnitLength);

            builder
                .Property(si => si.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .OwnsOne(
                    si => si.Address,
                    sa =>
                    {
                        sa.WithOwner();
                        sa.Property(a => a.Address);
                    });
        }
    }
}
