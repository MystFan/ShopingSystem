namespace ShopingRequestSystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Events;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using ShopingRequestSystem.Domain.RequestExecutions.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Infrastructure.Identity;
    using ShopingRequestSystem.Infrastructure.PublishedShopingRequests;
    using ShopingRequestSystem.Infrastructure.RequestExecutions;
    using ShopingRequestSystem.Infrastructure.ShopingRequests;

    internal class ShopingDbContext : IdentityDbContext<User>,
        IShopingRequestDbContext,
        IRequestExecutionDbContext,
        IPublishedShopingRequestDbContext,
        IIdentityDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public ShopingDbContext(
            DbContextOptions<ShopingDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<ShopingRequest> ShopingRequests { get; set; } = default!;

        public DbSet<ShopingItem> ShopingItems { get; set; } = default!;

        public DbSet<Requester> Requesters { get; set; } = default!;

        public DbSet<PublishedShopingRequest> PublishedShopingRequests { get; set; } = default!;

        public DbSet<Contractor> Contractors { get; set; } = default!;

        public DbSet<DeliveryOffer> DeliveryOffers { get; set; } = default!;

        public DbSet<RequestExecution> RequestExecutions { get; set; } = default!;

        public DbSet<Transport> Transports { get; set; } = default!;

        public DbSet<TransportType> TransportTypes { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
