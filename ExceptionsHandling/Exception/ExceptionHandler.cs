using ExceptionsHandling.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace ExceptionsHandling.Exception;

public static class ExceptionHandler
{

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError => {
            appError.Run(async context => {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                var contextRequest = context.Features.Get<IHttpRequestFeature>();

                context.Response.ContentType = "application/json";

                if(contextRequest == null)
                {
                    var errorString = new ErrorResponseData
                    {
                        ErrorCode = (int)HttpStatusCode.InternalServerError,
                        ErrorMessage = contextFeature.Error.Message,
                        Path = contextRequest.Path
                    }.ToString();

                    await context.Response.WriteAsync(errorString);
                }
            });
        });

    }

    public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandler>();
    }
}
