using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

public class FluentValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public FluentValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException validationException)
        {
            await HandleValidationExceptionAsync(context, validationException);
        }
    }

    private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var errors = exception.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
        var errorResponse = new
        {
            Message = "Validation failed",
            Errors = errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
