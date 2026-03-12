using System.Net;
using System.Text.Json;
using TransporteEscolar.Relatorios.Api.Models;
using TransporteEscolar.Relatorios.Application.Exceptions;

namespace TransporteEscolar.Relatorios.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro não tratado na requisição {Method} {Path}. TraceId: {TraceId}",
                context.Request.Method,
                context.Request.Path,
                context.TraceIdentifier);

            await HandleExceptionAsync(context, ex, _environment);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        IHostEnvironment environment)
    {
        var statusCode = exception switch
        {
            BusinessException => (int)HttpStatusCode.BadRequest,
            NotFoundException => (int)HttpStatusCode.NotFound,
            ConflictException => (int)HttpStatusCode.Conflict,
            ArgumentException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = new ErrorResponse
        {
            Sucesso = false,
            StatusCode = statusCode,
            Mensagem = statusCode == (int)HttpStatusCode.InternalServerError
                ? "Ocorreu um erro interno ao processar a requisição."
                : exception.Message,
            Detalhes = environment.IsDevelopment() ? exception.ToString() : null,
            DataHora = DateTime.UtcNow,
            TraceId = context.TraceIdentifier
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}