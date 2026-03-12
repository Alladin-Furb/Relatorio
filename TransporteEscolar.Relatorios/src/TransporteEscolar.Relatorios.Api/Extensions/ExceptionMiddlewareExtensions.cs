using TransporteEscolar.Relatorios.Api.Middlewares;

namespace TransporteEscolar.Relatorios.Api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}