namespace TransporteEscolar.Relatorios.Application.DTOs;

public class FrequenciaAlunoDto
{
    public Guid AlunoId { get; set; }
    public string NomeAluno { get; set; } = string.Empty;
    public int DiasConfirmados { get; set; }
    public int DiasCancelados { get; set; }
    public decimal PercentualFrequencia { get; set; }
}