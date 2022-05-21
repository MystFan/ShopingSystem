namespace ShopingRequestSystem.Domain.Requests
{
    using Autofac;
    using ShopingRequestSystem.Domain.Common;

    public class ShopingRequestDomainModule : Module
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
