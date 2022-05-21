namespace ShopingRequestSystem.Queries
{
    using Autofac;
    using Autofac.Pooling;
    using ShopingRequestSystem.Queries.Common.Contracts;
    using ShopingRequestSystem.Queries.Common.Data;

    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DapperConnection>().As<IDapperConnection>().PooledInstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IQueryRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
