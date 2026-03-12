using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IKmService
{
    Task<MediaKmDiariaDto> ObterMediaDiariaAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<KmPorDiaDto>> ObterPorDiaAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default);
}