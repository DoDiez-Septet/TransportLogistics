using System.Net;
using System.Text;

namespace OrderService.HandleExceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {

            if (exception.Data.Contains("status"))
            {
                context.Response.StatusCode = (int)(exception?.Data["status"] ?? HttpStatusCode.InternalServerError);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            
            var result = JsonConvert.SerializeObject(new
            {
                ErrorMessage = exception?.Message
            });
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
