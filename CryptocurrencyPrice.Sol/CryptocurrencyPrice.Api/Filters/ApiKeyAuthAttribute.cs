using System;
using System.Net;
using System.Threading.Tasks;
using CryptocurrencyPrice.Entities.MP.Base;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace CryptocurrencyPrice.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                Unauthorized(context);
                return;
            }

            IConfiguration _configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            string apiKey = _configuration.GetValue<string>(key: "ApiKey");

            if (!apiKey.Equals(potentialApiKey))
            {
                Unauthorized(context);
                return;
            }

            await next();
        }

        private static void Unauthorized(ActionExecutingContext context, string message = "Invalid ApiKey")
        {
            context.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
            context.Result = new JsonResult("NotAuthorized")
            {
                Value = new
                {
                    Result = Result.InvalidApiKey,
                    Message = message
                },
            };
        }
    }
}
