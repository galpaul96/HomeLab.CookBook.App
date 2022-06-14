using Newtonsoft.Json;
using System.Net;

namespace HomeLab.App.Infra.Middlewares
{
    /// <summary>
    /// GlobalExceptionHandler
    /// </summary>
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// GlobalExceptionHandler ctor
        /// </summary>
        /// <param name="next"></param>
        public GlobalExceptionHandler(RequestDelegate next) => _next = next;

        /// <summary>
        /// Middleware invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case Exception e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
