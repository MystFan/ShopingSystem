namespace ShopingRequestSystem.Application
{
    using Autofac;
    using MediatR;
    using System.Reflection;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Behaviours;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
