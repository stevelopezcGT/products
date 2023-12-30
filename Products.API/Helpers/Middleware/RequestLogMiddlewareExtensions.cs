namespace Products.API.Helpers.Middleware
{
    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
