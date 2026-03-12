using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Services;

public class IndicadorOperacionalService : IIndicadorOperacionalService
{
    private readonly IPresencaHistoricaRepository _presencaHistoricaRepository;
    private readonly IRotaHistoricaRepository _rotaHistoricaRepository;

    public IndicadorOperacionalService(
        IPresencaHistoricaRepository presencaHistoricaRepository,
        IRotaHistoricaRepository rotaHistoricaRepository)
    {
        _presencaHistoricaRepository = presencaHistoricaRepository;
        _rotaHistoricaRepository = rotaHistoricaRepository;
    }

    public async Task<IndicadorOperacionalDto> ObterAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default)
    {
        var inicio = new DateOnly(ano, mes, 1);
        var fim = inicio.AddMonths(1).AddDays(-1);

        var presencas = await _presencaHistoricaRepository.ObterPorPeriodoAsync(inicio, fim, cancellationToken);
        var rotas = await _rotaHistoricaRepository.ObterPorPeriodoAsync(inicio, fim, cancellationToken);

        var totalConfirmacoes = presencas.Count(x => x.ConfirmouPresenca);
        var totalCancelamentos = presencas.Count(x => x.CancelouPresenca);

        var mediaKmPorDia = rotas.Count == 0
            ? 0
            : rotas
                .GroupBy(x => x.Data)
                .Average(g => g.Sum(r => r.DistanciaKm));

        return new IndicadorOperacionalDto
        {
            MediaKmPorDia = decimal.Round(mediaKmPorDia, 2),
            TotalRotasPeriodo = rotas.Count,
            TotalPresencasConfirmadas = totalConfirmacoes,
            TotalCancelamentos = totalCancelamentos
        };
    }
}