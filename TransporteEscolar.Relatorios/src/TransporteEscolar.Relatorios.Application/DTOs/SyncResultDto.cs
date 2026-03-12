namespace TransporteEscolar.Relatorios.Application.DTOs;

public class SyncResultDto
{
    public string Operacao { get; set; } = string.Empty;
    public int RegistrosProcessados { get; set; }
    public bool Sucesso { get; set; }
    public string? Mensagem { get; set; }
}