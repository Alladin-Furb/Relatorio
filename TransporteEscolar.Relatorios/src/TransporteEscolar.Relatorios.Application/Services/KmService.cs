using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Services;

public class KmService : IKmService
{
    private readonly IRotaHistoricaRepository _rotaHistoricaRepository;

    public KmService(IRotaHistoricaRepository rotaHistoricaRepository)
    {
        _rotaHistoricaRepository = rotaHistoricaRepository;
    }

    public async Task<MediaKmDiariaDto> ObterMediaDiariaAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default)
    {
        var inicio = new DateOnly(ano, mes, 1);
        var fim = inicio.AddMonths(1).AddDays(-1);

        var rotas = await _rotaHistoricaRepository.ObterPorPeriodoAsync(inicio, fim, cancellationToken);

        var mediaKmPorDia = rotas.Count == 0
            ? 0
            : rotas
                .GroupBy(x => x.Data)
                .Average(g => g.Sum(r => r.DistanciaKm));

        return new MediaKmDiariaDto
        {
            Ano = ano,
            Mes = mes,
            MediaKmPorDia = decimal.Round(mediaKmPorDia, 2)
        };
    }

    public async Task<IReadOnlyCollection<KmPorDiaDto>> ObterPorDiaAsync(
        int ano,
        int mes,
        CancellationToken cancellationToken = default)
    {
        var inicio = new DateOnly(ano, mes, 1);
        var fim = inicio.AddMonths(1).AddDays(-1);

        var rotas = await _rotaHistoricaRepository.ObterPorPeriodoAsync(inicio, fim, cancellationToken);

        return rotas
            .GroupBy(x => x.Data)
            .OrderBy(x => x.Key)
            .Select(g => new KmPorDiaDto
            {
                Data = g.Key,
                TotalKm = decimal.Round(g.Sum(x => x.DistanciaKm), 2)
            })
            .ToList();
    }
}