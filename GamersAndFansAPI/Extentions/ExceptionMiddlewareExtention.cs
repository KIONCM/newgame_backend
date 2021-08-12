using System.Net;
using Contract;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GamersAndFansAPI.Extentions
{
    /// <summary>
    /// this class has been implemented from code-maze website Global Error Handling
    /// to read more see : https://code-maze.com/global-error-handling-aspnetcore
    /// </summary>
    public static class ExceptionMiddlewareExtention
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app , ILoggerManager loggerManager)
        {
            app.UseExceptionHandler(appError => {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        loggerManager.LogError("Something went wrong : " +
                            $"{contextFeature.Error.Message}" +
                            $"|{contextFeature.Error.InnerException}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
    
                    }
                });
            });
        }
    }
}
