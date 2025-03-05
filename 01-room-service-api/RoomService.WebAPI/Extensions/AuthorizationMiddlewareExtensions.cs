using Microsoft.AspNetCore.Builder;
using RoomService.WebAPI.Middleware;

namespace RoomService.WebAPI.Extensions
{
    public static class AuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}