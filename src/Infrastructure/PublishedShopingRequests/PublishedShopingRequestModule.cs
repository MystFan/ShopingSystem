namespace ShopingRequestSystem.Infrastructure.PublishedShopingRequests
{
    using Autofac;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    public class PublishedShopingRequestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingDbContext>()
                .As<IPublishedShopingRequestDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
