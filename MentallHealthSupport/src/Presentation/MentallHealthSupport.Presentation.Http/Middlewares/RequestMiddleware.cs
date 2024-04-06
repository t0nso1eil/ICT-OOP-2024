#pragma warning disable IDE0063

using MentallHealthSupport.Application.Exceptions;
using System.Diagnostics;

namespace MentallHealthSupport.Presentation.Http.Middlewares;

public class RequestMiddleware(ILogger<RequestMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var sw = Stopwatch.StartNew();
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var host = context.Request.Host.Host;
            var port = context.Request.Host.Port;
            var method = context.Request.Method;
            var endpoint = $"{context.Request.Path}{context.Request.QueryString}";

            logger.LogInformation($"Request from {ip} to {host}:{port} {method} {endpoint}");

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await next(context);

                sw.Stop();
                var response = await FormatResponse(context.Response);
                var elapsedTime = sw.Elapsed.TotalMilliseconds;

                logger.LogInformation($"Response for {ip} to {host}:{port} {method} {endpoint} responded {context.Response.StatusCode} in {elapsedTime:0.0000} ms. Response: {response}");

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
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
        logger.LogError(exception.Message);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsync("Internal Server Error.");
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return responseBody;
    }
}