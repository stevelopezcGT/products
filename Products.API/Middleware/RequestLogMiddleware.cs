using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace Products.API.Middleware;

public class RequestLogMiddleware
{
    const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0} sec";

    static readonly Serilog.ILogger Log = Serilog.Log.ForContext<RequestLogMiddleware>();

    private readonly RequestDelegate next;

    public RequestLogMiddleware(RequestDelegate _next)
    {
        this.next = _next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        await next(context);

        sw.Stop();
        var statusCode = context.Response?.StatusCode;
        var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

        var log = level == LogEventLevel.Error ? LogForErrorContext(context) : Log;
        log.Write(level, MessageTemplate, context.Request.Method, context.Request.Path, statusCode, sw.Elapsed.TotalSeconds);
    }

    static Serilog.ILogger LogForErrorContext(HttpContext httpContext)
    {
        var request = httpContext.Request;

        var result = Log
            .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
            .ForContext("RequestHost", request.Host)
            .ForContext("RequestProtocol", request.Protocol);

        if (request.HasFormContentType)
            result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

        return result;
    }
}
