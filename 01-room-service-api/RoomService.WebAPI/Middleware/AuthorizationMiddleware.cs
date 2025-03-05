using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RoomService.WebAPI.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string PasswordKeyHeader = "passwordKey";
        private const string ExpectedPasswordValue = "passwordKey123456789";

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Verificar si la solicitud contiene el encabezado correcto
            if (context.Request.Headers.TryGetValue(PasswordKeyHeader, out var passwordValue))
            {
                // Verificar si el valor del encabezado es correcto
                if (passwordValue == ExpectedPasswordValue)
                {
                    // El encabezado y el valor son correctos, continuar con la solicitud
                    await _next(context);
                    return;
                }
            }

            // Si el encabezado no está presente o el valor es incorrecto, devolver 403 Forbidden
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Acceso denegado. Se requiere autorización.");
        }
    }
}