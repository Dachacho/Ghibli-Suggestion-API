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

            var statusCode = ex switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            
            context.Response.StatusCode = statusCode;

            var response = new
            {
                status = statusCode,
                message = statusCode switch
                {
                    StatusCodes.Status400BadRequest => "Bad Request",
                    StatusCodes.Status404NotFound => "Not Found",
                    _ => "Internal Server Error",
                }
            };
            
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}