using System.Text.Json;
using FluentValidation;
using Mycar.Common.Exceptions;

namespace Mycar.WebAPI.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Web api exception");

                throw;
            }
        }
        catch (NotFoundException notFoundException)
        {
            await ReturnErrorAsync(
                context,
                NotFoundException.StatusCode,
                new
                {
                    Type = notFoundException.GetType().Name,
                    Message = "Item not found.",
                    Values = new { notFoundException.Name, notFoundException.Value }
                });
        }
        catch (ValidationException validationException)
        {
            await ReturnErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                new
                {
                    Type = validationException.GetType().Name,
                    validationException.Message
                });
        }
        catch (BadHttpRequestException badHttpRequestException)
        {
            await ReturnErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                new
                {
                    Type = badHttpRequestException.GetType().Name,
                    badHttpRequestException.Message
                });
        }
        catch (UnauthorizedAccessException unauthorizedAccessException)
        {
            await ReturnErrorAsync(
                context,
                StatusCodes.Status401Unauthorized,
                new
                {
                    Type = unauthorizedAccessException.GetType().Name,
                    unauthorizedAccessException.Message
                });
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unexpected exception");

            //TODO: Remove stacktrace & ex after development phase
            await ReturnErrorAsync(
                context,
                StatusCodes.Status500InternalServerError,
                new
                {
                    Type = exception.GetType().Name,
                    exception.Message
                });
        }
    }

    private static Task ReturnErrorAsync(HttpContext context, int statusCode, object? response = null)
    {
        context.Response.StatusCode = statusCode;

        if (response == null) return Task.CompletedTask;

        var json = JsonSerializer.Serialize(response);
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(json);
    }
}