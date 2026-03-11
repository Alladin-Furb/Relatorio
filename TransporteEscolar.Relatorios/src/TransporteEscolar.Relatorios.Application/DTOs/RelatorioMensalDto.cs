namespace TransporteEscolar.Relatorios.Application.DTOs;

public class RelatorioMensalDto
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public int TotalConfirmacoes { get; set; }
    public int TotalCancelamentos { get; set; }
    public decimal MediaKmPorDia { get; set; }
    public int TotalRotas { get; set; }
}