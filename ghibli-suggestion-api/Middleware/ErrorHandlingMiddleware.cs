using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ghibli_suggestion_api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, $"Unhandled exception occured: {context.Request.Path}");
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var problem = new ProblemDetails
            {
                Title = "An unhandled exception occured",
                Status = StatusCodes.Status500InternalServerError,
                Detail = "An unhandled exception occured"
            };
            
            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}