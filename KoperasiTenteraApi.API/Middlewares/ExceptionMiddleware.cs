using KoperasiTenteraApi.Domain.Exceptions;
using System.Net;

namespace KoperasiTenteraApi.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Resource not found");
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsync(ex.Message); // Send the exception message to the client
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                // Create a custom error response
                var errorResponse = new { message = ex.Message };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
