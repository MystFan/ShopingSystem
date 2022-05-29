namespace ShopingRequestSystem.Web.Common
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Linq;

    internal class MarkAsAuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            ControllerActionDescriptor descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null)
            {
                bool isAuthorize = descriptor.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
                if (isAuthorize)
                {
                    operation.Summary = $"{operation.Summary} (Authorize)";
                }
            }
        }
    }
}
