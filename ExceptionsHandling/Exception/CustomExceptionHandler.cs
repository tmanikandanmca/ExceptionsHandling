using Azure;
using ExceptionsHandling.Models.Exceptions;
using System;
using System.Net;

namespace ExceptionsHandling.Exception;

public class CustomExceptionHandler
{

    private readonly RequestDelegate _Next;

    public CustomExceptionHandler(RequestDelegate Next)
    {
        _Next = Next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _Next(context);
        }
        catch (System.Exception ex)
        {

            await HandleExceptionAsync(context, ex);
        }
    }

    public Task HandleExceptionAsync(HttpContext httpcontext, System.Exception ex)
    {
        httpcontext.Response.ContentType = "application/json";

        var errorMessage= new ErrorResponseData
        {
            ErrorCode=(int)HttpStatusCode.InternalServerError,
            ErrorMessage = ex.Message,
            Path= httpcontext.Request.Path
        }.ToString();

        return httpcontext.Response.WriteAsync(errorMessage);
    }

}
