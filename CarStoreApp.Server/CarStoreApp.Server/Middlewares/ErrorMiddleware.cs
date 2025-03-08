namespace CarStoreApp.Server.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);

            }
            catch (Exception ex)
            {
                await ctx.Response.WriteAsJsonAsync(new { Message = ex.Message, StatusCode = ctx.Response.StatusCode, StackTrace = ex.StackTrace });

            }
        }
    }

    public static class ErrorExtensions
    {
        public static IApplicationBuilder UseError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
