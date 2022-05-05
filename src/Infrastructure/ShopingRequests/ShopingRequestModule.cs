namespace ShopingRequestSystem.Infrastructure.ShopingRequests
{
    using Autofac;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    public class ShopingRequestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingDbContext>()
                .As<IShopingRequestDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
