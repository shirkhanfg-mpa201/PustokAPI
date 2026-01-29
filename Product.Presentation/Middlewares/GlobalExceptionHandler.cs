using Pustok.Business.Abstractions;
using Pustok.Business.Dtos.ResultDtos;

namespace Product.Presentation.Middlewares
{
    public class GlobalExceptionHandler
    {

        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ResultDto errorResult = new ResultDto
                {
                    IsSucceed = false,
                    Message = "Internal server error.",
                    StatusCode = 500
                };
                if (ex is IBaseException baseException)
                {

                    errorResult.Message = ex.Message;
                    errorResult.StatusCode = baseException.StatusCode;

                }
                context.Response.StatusCode = errorResult.StatusCode;
                await context.Response.WriteAsJsonAsync(errorResult);

            }
        }
    }
}
