namespace ShopingRequestSystem.Domain.PublishedRequests
{
    using Autofac;
    using ShopingRequestSystem.Domain.Common;

    public class PublishedRequestDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IFactory<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
