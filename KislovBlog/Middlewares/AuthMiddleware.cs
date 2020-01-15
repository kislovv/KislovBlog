using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace KislovBlog.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthOption _option;
        public AuthMiddleware(RequestDelegate next, IOptionsMonitor<AuthOption> options)
        {
            _next = next;
            _option = options.CurrentValue;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Auth"];
            if (authHeader == _option.AuthKey)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}
