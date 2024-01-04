using Newtonsoft.Json;
using Products.Application.Exceptions;
using Serilog;
using System.Net;

namespace Products.API.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate _next, ILogger<ExceptionHandlerMiddleware> _logger)
    {
        next = _next;
        logger = _logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (exception)
        {
            case FluentValidation.ValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(new { ErrorMessage = badRequestException.Message });
                break;
            case NotFoundException notFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case KeyNotFoundException keyNotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                result = JsonConvert.SerializeObject(new { ErrorMessage = keyNotFoundException.Message });
                break;
            case Exception ex:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(exception.Message.ToString());
        }
        logger.LogError(exception.Message);
        return context.Response.WriteAsync(result);
    }
}
