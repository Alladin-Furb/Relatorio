namespace TransporteEscolar.Relatorios.Domain.Entities;

public class PresencaHistorica
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public DateOnly Data { get; set; }
    public bool ConfirmouPresenca { get; set; }
    public bool CancelouPresenca { get; set; }
    public DateTime? DataConfirmacao { get; set; }
    public DateTime? DataCancelamento { get; set; }
    public string? EnderecoUtilizado { get; set; }

    public AlunoSnapshot? Aluno { get; set; }
}