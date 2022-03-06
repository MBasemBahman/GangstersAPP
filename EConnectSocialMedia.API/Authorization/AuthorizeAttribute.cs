using Microsoft.AspNetCore.Mvc.Filters;
namespace EConnectSocialMedia.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            #region Main Filters

            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAllAttribute>().Any())
            {
                return;
            }

            #region secret and app key

            string secret = context.HttpContext.Request.Headers["Secret"];
            string ApiKey = context.HttpContext.Request.Headers["Api-Key"];
            string UserAgent = context.HttpContext.Request.Headers["User-Platform"];

            IServiceProvider services = context.HttpContext.RequestServices;

            AppSettings _appSettings = services.GetService<IOptions<AppSettings>>().Value;

            if (string.IsNullOrEmpty(secret) ||
                string.IsNullOrEmpty(ApiKey) ||
                string.IsNullOrEmpty(UserAgent))
            {
                context.Result = new JsonResult(new { message = "BadRequest" }) { StatusCode = StatusCodes.Status400BadRequest };
                return;
            }
            else if (secret != _appSettings.Secret)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            else
            {
                if (UserAgent == "Android")
                {
                    if (ApiKey != _appSettings.AndroidAPIKEY)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                else if (UserAgent == "IOS")
                {
                    if (ApiKey != _appSettings.IOSAPIKEY)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                else if (UserAgent == "Web")
                {
                    if (ApiKey != _appSettings.WebAPIKEY)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                else
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }

            #endregion

            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            #endregion

            // authorization
            AuthorizedAccount account = (AuthorizedAccount)context.HttpContext.Items["Account"];
            if (account == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
        }
    }
}