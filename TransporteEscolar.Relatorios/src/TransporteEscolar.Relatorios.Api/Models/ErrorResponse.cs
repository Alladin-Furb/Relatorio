namespace TransporteEscolar.Relatorios.Api.Models;

public class ErrorResponse
{
    public bool Sucesso { get; set; }
    public int StatusCode { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string? Detalhes { get; set; }
    public DateTime DataHora { get; set; }
    public string? TraceId { get; set; }
}