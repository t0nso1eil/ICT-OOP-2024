using MentallHealthSupport.Application.Exceptions;

namespace MentallHealthSupport.Presentation.Http.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        var statusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ConflictException => StatusCodes.Status409Conflict,
            IncorrectInputException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,
        };

        if (statusCode is StatusCodes.Status500InternalServerError)
        {
            await HandleInternalException(httpContext, exception);
            return;
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(exception.Message);
    }

    private async Task HandleInternalException(HttpContext httpContext, Exception exception)
    {
        _logger.LogError(exception.Message);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsync("Internal Server Error!");
    }
}