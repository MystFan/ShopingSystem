namespace ShopingRequestSystem.Startup
{
    using Autofac;
    using ShopingRequestSystem.Application;
    using ShopingRequestSystem.Infrastructure;
    using ShopingRequestSystem.Queries;

    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<QueriesModule>();
            builder.RegisterModule<InfrastructureModule>();
        }
    }
}
