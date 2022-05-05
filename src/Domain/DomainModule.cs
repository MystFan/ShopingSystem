namespace ShopingRequestSystem.Domain
{
    using Autofac;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.PublishedShopingRequests;
    using ShopingRequestSystem.Domain.RequestExecutions;
    using ShopingRequestSystem.Domain.ShopingRequests;

    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ShopingRequestModule>();
            builder.RegisterModule<PublishedShopingRequestModule>();
            builder.RegisterModule<RequestExecutionModule>();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IFactory<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
