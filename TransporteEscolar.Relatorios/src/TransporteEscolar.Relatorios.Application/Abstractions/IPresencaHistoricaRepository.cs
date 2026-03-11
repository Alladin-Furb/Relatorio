using TransporteEscolar.Relatorios.Domain.Entities;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IPresencaHistoricaRepository
{
    Task<IReadOnlyCollection<PresencaHistorica>> ObterPorPeriodoAsync(
        DateOnly inicio,
        DateOnly fim,
        CancellationToken cancellationToken = default);
}