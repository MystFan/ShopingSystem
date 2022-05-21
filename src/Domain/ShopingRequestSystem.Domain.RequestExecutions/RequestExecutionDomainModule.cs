namespace ShopingRequestSystem.Domain.RequestExecutions
{
    using Autofac;
    using ShopingRequestSystem.Domain.Common;

    public class RequestExecutionDomainModule : Module
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
