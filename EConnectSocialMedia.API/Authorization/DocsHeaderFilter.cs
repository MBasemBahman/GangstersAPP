using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EConnectSocialMedia.API.Authorization
{
    public class DocsHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            ControllerActionDescriptor ActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (ActionDescriptor != null)
            {
                bool allowAll = ActionDescriptor.EndpointMetadata.OfType<AllowAllAttribute>().Any();
                bool allowAnonymous = ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

                if (!allowAll)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "Secret",
                        In = ParameterLocation.Header,
                        Description = "Secret key",
                        Required = true
                    });

                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "User-Platform",
                        In = ParameterLocation.Header,
                        Description = "Android, IOS, Web",
                        Required = true
                    });

                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "Api-Key",
                        In = ParameterLocation.Header,
                        Description = "Api Key depend on your platform",
                        Required = true
                    });
                }
                if (!allowAnonymous && !allowAll)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "Authorization-Token",
                        In = ParameterLocation.Header,
                        Description = "Your account token",
                        Required = true
                    });
                }
            }
        }
    }
}
