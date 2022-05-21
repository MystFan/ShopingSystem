namespace ShopingRequestSystem.Infrastructure.RequestExecutions.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShopingRequestSystem.Domain.RequestExecutions.Models;
    using static ShopingRequestSystem.Domain.RequestExecutions.Models.ModelConstants.ShopingRequest;
    using static ShopingRequestSystem.Domain.RequestExecutions.Models.ModelConstants.RequestExecution;

    internal sealed class RequestExecutionDbConfiguration : IEntityTypeConfiguration<RequestExecution>
    {
        public void Configure(EntityTypeBuilder<RequestExecution> builder)
        {
            builder
                .HasKey(re => re.Id);

            builder
                .Property(re => re.RequestId)
                .IsRequired()
                .HasMaxLength(MaxRequestIdLength);

            builder
                .Property(re => re.ContractorId)
                .IsRequired();

            builder
                .Property(re => re.PaidSum)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(re => re.Notes)
                .IsRequired(false)
                .HasMaxLength(MaxNotesLength);

            builder
                .HasMany(re => re.Transports)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("transports");
        }
    }
}
