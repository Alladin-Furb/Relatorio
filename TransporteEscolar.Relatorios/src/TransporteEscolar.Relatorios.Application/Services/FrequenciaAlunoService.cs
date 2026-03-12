using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Services;

public class FrequenciaAlunoService : IFrequenciaAlunoService
{
    private readonly IPresencaHistoricaRepository _presencaHistoricaRepository;
    private readonly IAlunoSnapshotRepository _alunoSnapshotRepository;

    public FrequenciaAlunoService(
        IPresencaHistoricaRepository presencaHistoricaRepository,
        IAlunoSnapshotRepository alunoSnapshotRepository)
    {
        _presencaHistoricaRepository = presencaHistoricaRepository;
        _alunoSnapshotRepository = alunoSnapshotRepository;
    }

    public async Task<FrequenciaAlunoDto> CalcularAsync(
        Guid alunoId,
        int ano,
        int mes,
        CancellationToken cancellationToken = default)
    {
        var inicio = new DateOnly(ano, mes, 1);
        var fim = inicio.AddMonths(1).AddDays(-1);

        var aluno = await _alunoSnapshotRepository.ObterPorIdAsync(alunoId, cancellationToken);

        var presencas = await _presencaHistoricaRepository.ObterPorAlunoEPeriodoAsync(
            alunoId,
            inicio,
            fim,
            cancellationToken);

        var diasConfirmados = presencas.Count(x => x.ConfirmouPresenca);
        var diasCancelados = presencas.Count(x => x.CancelouPresenca);
        var totalRegistros = presencas.Count;

        var percentualFrequencia = totalRegistros == 0
            ? 0
            : decimal.Round((decimal)diasConfirmados / totalRegistros * 100m, 2);

        return new FrequenciaAlunoDto
        {
            AlunoId = alunoId,
            NomeAluno = aluno?.Nome ?? "Aluno não encontrado",
            DiasConfirmados = diasConfirmados,
            DiasCancelados = diasCancelados,
            PercentualFrequencia = percentualFrequencia
        };
    }

    public async Task<IReadOnlyCollection<FrequenciaAlunoDto>> CalcularTodosAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default)
    {
        var alunos = await _alunoSnapshotRepository.ObterTodosAsync(cancellationToken);

        var resultados = new List<FrequenciaAlunoDto>();

        foreach (var aluno in alunos)
        {
            var frequencia = await CalcularAsync(aluno.Id, ano, mes, cancellationToken);
            resultados.Add(frequencia);
        }

        return resultados
            .OrderByDescending(x => x.PercentualFrequencia)
            .ThenBy(x => x.NomeAluno)
            .ToList();
    }
}