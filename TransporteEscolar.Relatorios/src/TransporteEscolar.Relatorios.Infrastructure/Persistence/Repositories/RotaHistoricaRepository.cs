using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Domain.Entities;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;

namespace TransporteEscolar.Relatorios.Infrastructure.Persistence.Repositories;

public class RotaHistoricaRepository : IRotaHistoricaRepository
{
    private readonly RelatoriosDbContext _context;

    public RotaHistoricaRepository(RelatoriosDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<RotaHistorica>> ObterPorPeriodoAsync(
        DateOnly inicio,
        DateOnly fim,
        CancellationToken cancellationToken = default)
    {
        return await _context.RotasHistoricas
            .AsNoTracking()
            .Where(x => x.Data >= inicio && x.Data <= fim)
            .ToListAsync(cancellationToken);
    }
}