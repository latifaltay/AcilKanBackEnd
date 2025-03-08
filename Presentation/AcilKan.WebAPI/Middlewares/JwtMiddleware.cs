using AcilKan.Persistence.Services;

namespace AcilKan.WebAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && TokenBlacklist.IsTokenBlacklisted(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Token is blacklisted.");
                return;
            }

            await _next(context);
        }
    }
}
