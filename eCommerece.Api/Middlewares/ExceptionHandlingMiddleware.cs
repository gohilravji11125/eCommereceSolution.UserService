namespace eCommerece.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.GetType().ToString()}: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = new { Message = "An unexpected error occurred.", Details = ex.Message };
                if(ex.InnerException is not null)
                {
                    _logger.LogError($"Inner Exception: {ex.InnerException.GetType().ToString()}: {ex.InnerException.Message}");
                    errorResponse = new { Message = "An unexpected error occurred.", Details = $"{ex.Message} Inner Exception: {ex.InnerException.Message}" };
                }
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
