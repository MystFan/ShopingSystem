namespace ShopingRequestSystem.Infrastructure
{
    using Autofac;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Infrastructure.Common;
    using ShopingRequestSystem.Infrastructure.Common.Events;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;
    using ShopingRequestSystem.Infrastructure.Identity;
    using ShopingRequestSystem.Infrastructure.PublishedShopingRequests;
    using ShopingRequestSystem.Infrastructure.RequestExecutions;
    using ShopingRequestSystem.Infrastructure.ShopingRequests;

    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ShopingRequestModule>();
            builder.RegisterModule<PublishedShopingRequestModule>();
            builder.RegisterModule<RequestExecutionModule>();

            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().InstancePerDependency();
            builder.RegisterType<DatabaseInitializer>().As<IInitializer>().InstancePerDependency();
            builder.RegisterType<ShopingDbContext>().As<IIdentityDbContext>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IDomainRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())   
                .AsClosedTypesOf(typeof(IQueryRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
