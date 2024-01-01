using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BulbEd.Interfaces;

namespace BulbEd.Middleware
{
    public class TokenBlacklistMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenBlacklistMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITokenBlacklistService tokenBlacklistService)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = context.Request.Headers["Authorization"].ToString();
                var authHeaderValues = authHeader.Split(' ');

                if (authHeaderValues.Length == 2 && authHeaderValues[0] == "Bearer")
                {
                    var token = authHeaderValues[1];

                    if (await tokenBlacklistService.IsTokenBlacklisted(token))
                    {
                        context.Response.StatusCode = 401; // Unauthorized
                        await context.Response.WriteAsync("This token is blacklisted.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}