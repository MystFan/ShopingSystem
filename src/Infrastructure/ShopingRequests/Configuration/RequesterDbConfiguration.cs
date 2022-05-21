namespace ShopingRequestSystem.Infrastructure.ShopingRequests.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.Requests.Models;
    using static ShopingRequestSystem.Domain.Requests.Models.ModelConstants.Requester;

    internal sealed class RequesterDbConfiguration : IEntityTypeConfiguration<Requester>
    {
        public void Configure(EntityTypeBuilder<Requester> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(r => r.UserId)
                .IsRequired();

            builder
                .OwnsOne(
                    r => r.PhoneNumber,
                    pn =>
                    {
                        pn.WithOwner();
                        pn.Property(pn => pn.Number);
                    });
        }
    }
}
