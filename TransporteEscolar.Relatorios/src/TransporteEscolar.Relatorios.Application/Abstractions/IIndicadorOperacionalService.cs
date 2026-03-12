using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IIndicadorOperacionalService
{
    Task<IndicadorOperacionalDto> ObterAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default);
}