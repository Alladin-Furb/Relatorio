using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface ISyncHistoricoService
{
    Task<SyncResultDto> ImportarPresencasAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default);

    Task<SyncResultDto> ImportarRotasAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default);

    Task<SyncResultDto> ImportarAlunosAsync(
        CancellationToken cancellationToken = default);

    Task<SyncResultDto> ImportarPeriodoAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default);
}