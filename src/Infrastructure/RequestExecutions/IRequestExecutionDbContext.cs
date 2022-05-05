namespace ShopingRequestSystem.Infrastructure.RequestExecutions
{
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.RequestExecutions.Models;

    public interface IRequestExecutionDbContext
    {
        DbSet<RequestExecution> RequestExecutions { get; }

        DbSet<Transport> Transports { get; }

        DbSet<TransportType> TransportTypes { get; }
    }
}
