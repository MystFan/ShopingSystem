namespace ShopingRequestSystem.Application
{
    using Autofac;
    using MediatR;
    using System.Reflection;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Behaviours;
    using ShopingRequestSystem.Domain.Requests;
    using ShopingRequestSystem.Domain.PublishedRequests;
    using ShopingRequestSystem.Domain.RequestExecutions;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ShopingRequestDomainModule>();
            builder.RegisterModule<PublishedRequestDomainModule>();
            builder.RegisterModule<RequestExecutionDomainModule>();

            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
