using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Console.WriteLine("Handling exception...");

        if (context.Response.HasStarted)
        {
            Console.WriteLine("Response has already started.");
            return;
        }

        Console.WriteLine("Setting response details.");
        context.Response.ContentType = "application/json";

        if (exception is ValidationException validationException)
        {
            Console.WriteLine("Validation exception detected.");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = validationException.Errors;
            var errorResponse = new
            {
                Message = "Validation failed",
                Errors = errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
        else
        {
            Console.WriteLine("General exception detected.");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorResponse = new
            {
                Message = "An unexpected error occurred.",
                Details = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        Console.WriteLine("Exception handling completed.");
    }


}
