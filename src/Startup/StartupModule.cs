namespace ShopingRequestSystem.Startup
{
    using Autofac;
    using ShopingRequestSystem.Application;
    using ShopingRequestSystem.Domain;
    using ShopingRequestSystem.Infrastructure;

    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
        }
    }
}
