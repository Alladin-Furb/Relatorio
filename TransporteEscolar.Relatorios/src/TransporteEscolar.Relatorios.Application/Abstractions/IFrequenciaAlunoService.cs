using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IFrequenciaAlunoService
{
    Task<FrequenciaAlunoDto> CalcularAsync(
        Guid alunoId,
        int ano,
        int mes,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<FrequenciaAlunoDto>> CalcularTodosAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default);
}