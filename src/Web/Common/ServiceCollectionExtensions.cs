namespace ShopingRequestSystem.Web.Common
{
    using System;
    using System.IO;
    using System.Reflection;
    using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;

    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shoping system",
                    Version = "v1",
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Added in order for the Swagger Authorization to work by entering 'Bearer {token}' for more information on the issue you can check https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/603
                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[] { }
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                config.ExampleFilters();
                config.OperationFilter<MarkAsAuthorizeOperationFilter>();
            });

            services.AddFluentValidationRulesToSwagger();
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
        }
    }
}
