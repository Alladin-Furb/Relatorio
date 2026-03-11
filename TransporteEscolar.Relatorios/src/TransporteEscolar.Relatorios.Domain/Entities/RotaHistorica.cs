namespace TransporteEscolar.Relatorios.Domain.Entities;

public class RotaHistorica
{
    public Guid Id { get; set; }
    public DateOnly Data { get; set; }
    public decimal DistanciaKm { get; set; }
    public int QuantidadeAlunosTransportados { get; set; }
}