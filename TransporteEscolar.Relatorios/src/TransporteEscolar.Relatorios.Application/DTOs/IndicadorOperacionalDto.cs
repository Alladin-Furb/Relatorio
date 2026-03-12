namespace TransporteEscolar.Relatorios.Application.DTOs;

public class IndicadorOperacionalDto
{
    public decimal MediaKmPorDia { get; set; }
    public int TotalRotasPeriodo { get; set; }
    public int TotalPresencasConfirmadas { get; set; }
    public int TotalCancelamentos { get; set; }
}