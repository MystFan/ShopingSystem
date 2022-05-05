namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using static ShopingRequestSystem.Domain.PublishedShopingRequests.Models.ModelConstants.Contractor;

    internal sealed class ContractorDbConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.UserId)
                .IsRequired();

            builder
                .OwnsOne(
                    c => c.PhoneNumber,
                    pn =>
                    {
                        pn.WithOwner();
                        pn.Property(pn => pn.Number);
                    });
        }
    }
}
