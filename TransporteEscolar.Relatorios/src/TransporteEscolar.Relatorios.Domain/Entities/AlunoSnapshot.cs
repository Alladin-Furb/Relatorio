namespace TransporteEscolar.Relatorios.Domain.Entities;

public class AlunoSnapshot
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}