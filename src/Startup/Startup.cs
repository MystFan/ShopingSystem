namespace ShopingRequestSystem.Startup
{
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Autofac;
    using MediatR;
    using ShopingRequestSystem.Infrastructure;
    using ShopingRequestSystem.Web;
    using ShopingRequestSystem.Web.Common;
    using ShopingRequestSystem.Application;
    using ShopingRequestSystem.Infrastructure.Common;
    using ShopingRequestSystem.Web.Middleware;
    using ShopingRequestSystem.Queries;
    using ShopingRequestSystem.Queries.Common;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(provider => this.Configuration);
            services.AddOptions()
                .Configure<ApplicationSettings>(
                    this.Configuration.GetSection(nameof(ApplicationSettings)),
                    options => options.BindNonPublicProperties = true)
                .Configure<ConnectionStrings>(
                    this.Configuration.GetSection(nameof(ConnectionStrings)),
                    options => options.BindNonPublicProperties = true)
                .AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationModule)))
                .AddMediatR(
                    Assembly.GetAssembly(typeof(ApplicationModule)),
                    Assembly.GetAssembly(typeof(QueriesModule)))
                .AddInfrastructure(this.Configuration)
                .AddWebComponents();

            services.AddSwagger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new StartupModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app
                .UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers())
                .Initialize();
        }
    }
}
