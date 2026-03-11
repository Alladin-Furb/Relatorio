using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Domain.Entities;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;

namespace TransporteEscolar.Relatorios.Infrastructure.Persistence.Repositories;

public class PresencaHistoricaRepository : IPresencaHistoricaRepository
{
    private readonly RelatoriosDbContext _context;

    public PresencaHistoricaRepository(RelatoriosDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<PresencaHistorica>> ObterPorPeriodoAsync(
        DateOnly inicio,
        DateOnly fim,
        CancellationToken cancellationToken = default)
    {
        return await _context.PresencasHistoricas
            .AsNoTracking()
            .Where(x => x.Data >= inicio && x.Data <= fim)
            .ToListAsync(cancellationToken);
    }
}