namespace ShopingRequestSystem.Infrastructure.RequestExecutions
{
    using Autofac;
    using ShopingRequestSystem.Infrastructure.Common.Persistence;

    public class RequestExecutionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingDbContext>()
                .As<IRequestExecutionDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
