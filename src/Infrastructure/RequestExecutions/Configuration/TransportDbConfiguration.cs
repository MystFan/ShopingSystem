namespace ShopingRequestSystem.Infrastructure.RequestExecutions.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.RequestExecutions.Models;
    using static ShopingRequestSystem.Domain.RequestExecutions.Models.ModelConstants.Transport;

    internal sealed class TransportDbConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .HasOne(t => t.TransportType)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
