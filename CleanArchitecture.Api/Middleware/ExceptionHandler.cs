
using CleanArchitecture.Application.Exceptions;
using System.Text.Json;

namespace CleanArchitecture.Api.Middleware;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
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
        catch (BadRequestException badRequestException)
        {
            _logger.LogError(badRequestException, "BadRequestException");
            var problemDetails = new CustomProblemDetails
            {
                Title = "Bad Request",
                Detail = badRequestException.Message,
                Status = StatusCodes.Status400BadRequest,
                Type = "https://httpstatuses.com/400",
                ValidationErrors = badRequestException.ValidationErrors
            };
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        catch(NotFoundException notFoundException)
        {
            _logger.LogError(notFoundException, "NotFoundException");
            var problemDetails = new CustomProblemDetails
            {
                Title = "Not Found",
                Detail = notFoundException.Message,
                Status = StatusCodes.Status404NotFound,
                Type = "https://httpstatuses.com/404"
            };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Exception");
            var problemDetails = new CustomProblemDetails
            {
                Title = "Internal Server Error",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://httpstatuses.com/500"
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }   

}
