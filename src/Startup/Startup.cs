namespace ShopingRequestSystem.Startup
{
    using Web.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Autofac;
    using ShopingRequestSystem.Application;
    using ShopingRequestSystem.Infrastructure;
    using ShopingRequestSystem.Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWebComponents();
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
