using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IRelatorioMensalService
{
    Task<RelatorioMensalDto> GerarAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default);
}