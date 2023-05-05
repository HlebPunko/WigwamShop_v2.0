using System.Net;

namespace Favorite.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nextRequest;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _nextRequest = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _nextRequest(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, DateTime.Now);
                await HandleExtensionAsync(context, ex);
            }
        }

        private static Task HandleExtensionAsync(HttpContext context, Exception exception)
        {
            var resultAndCode = (HttpStatusCode.InternalServerError, string.Empty);

            resultAndCode = exception switch
            {
                ArgumentNullException argumentNullException => (HttpStatusCode.BadRequest, argumentNullException.Message),
                ArgumentException argumentException => (HttpStatusCode.BadRequest, argumentException.Message),
                _ => (HttpStatusCode.InternalServerError, exception.Message),
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)resultAndCode.ToTuple().Item1;

            return context.Response.WriteAsync(resultAndCode.ToTuple().Item2);
        }
    }
}
