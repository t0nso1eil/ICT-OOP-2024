using MentallHealthSupport.Application.Exceptions;
using System.Diagnostics;

namespace MentallHealthSupport.Presentation.Http.Middlewares;

public class RequestMiddleware : IMiddleware
{
    private readonly ILogger<RequestMiddleware> _logger;

    public RequestMiddleware(ILogger<RequestMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var ip = context.Connection.RemoteIpAddress?.MapToIPv4() + ":" + context.Connection.RemotePort;
            var host = context.Request.Host.ToString();
            var protocol = context.Request.Protocol;
            var method = context.Request.Method;
            var endpoint = context.Request.Path;

            _logger.LogInformation($"Request to {ip} {host} {protocol} by {method} to {endpoint}");
            await next(context);

            // sw.Stop();
            // var response = await FormatResponse(context.Response);
            // var elapsedTime = sw.Elapsed.TotalMilliseconds;
            // _logger.LogInformation($"Response for {ip} by {method} to {endpoint} responded {context.Response.StatusCode} in {elapsedTime:0.0000} ms. Response: {response}");
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
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

    // private async Task<string> FormatResponse(HttpResponse response)
    // {
    //     response.Body.Seek(0, SeekOrigin.Begin);
    //     var responseBody = await new StreamReader(response.Body).ReadToEndAsync();
    //     response.Body.Seek(0, SeekOrigin.Begin);
    //     return responseBody;
    // }
}