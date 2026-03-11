using TransporteEscolar.Relatorios.Domain.Entities;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IRotaHistoricaRepository
{
    Task<IReadOnlyCollection<RotaHistorica>> ObterPorPeriodoAsync(
        DateOnly inicio,
        DateOnly fim,
        CancellationToken cancellationToken = default);
}