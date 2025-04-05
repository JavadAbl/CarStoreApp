using CarStoreApp.Server.Helpers.Errors;

namespace CarStoreApp.Server.Middlewares
{
    public class ErrorMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {


        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await next(ctx);
            }
            catch (Exception ex)
            {

                dynamic errObj = ex;
                var statusCode = errObj.GetType().GetProperty("StatusCode");
                if (statusCode != null)
                {
                    statusCode = errObj.StatusCode;
                }
                else
                    statusCode = 500;

                ctx.Response.StatusCode = statusCode;

                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = statusCode,
                    StackTrace = env.IsDevelopment() ? ex.StackTrace : null
                };

                ctx.Response.ContentType = "application/json";

                await ctx.Response.WriteAsJsonAsync(errorResponse);
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
