using System;
using System.Net;
using CryptocurrencyPrice.Entities.MP.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CryptocurrencyPrice.Api.Helpers
{
    /// <summary>
    /// Handler to catch all exceptions in program, this return generic error
    /// </summary>
    public static class CustomException
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        IConfiguration configuration = context.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
                        context.Response.StatusCode = (int)HttpStatusCode.OK;

                        await context.Response.WriteAsync(
                            Newtonsoft.Json.JsonConvert.SerializeObject(new ExceptionOut()
                            {
                                Result = Result.GenericError,
                                Exception = contextFeature.Error.Message + " trace " + contextFeature.Error.StackTrace,
                                Message = "Internal Server Error."
                            }));
                    }
                });
            });
        }
    }
}
