using System.Reflection;

namespace Products.API.Helpers.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var currentDateTime = DateTime.UtcNow;
            await _next(context);
            var request = DateTime.UtcNow.Subtract(currentDateTime);
            WriteLog($"Request {context.Request.Method} {context.Request.Path}; Response sent: {context.Response.StatusCode}; Time Taked: {request.Seconds} seconds");
        }

        private void WriteLog(string message)
        {
            var directoryPath = AppContext.BaseDirectory + "/log/";
            var path = Path.Combine(directoryPath, $"{Assembly.GetExecutingAssembly().GetName().Name}-{DateTime.UtcNow.ToString("MMM/dd/yyyy").Replace("/", "_")}.txt");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!File.Exists(path))
                File.Create(path);

            File.AppendAllText(path, message + "\n");
        }
    }
}
