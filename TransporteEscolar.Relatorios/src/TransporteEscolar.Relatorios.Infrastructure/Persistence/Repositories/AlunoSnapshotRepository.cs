using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Domain.Entities;
using TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;

namespace TransporteEscolar.Relatorios.Infrastructure.Persistence.Repositories;

public class AlunoSnapshotRepository : IAlunoSnapshotRepository
{
    private readonly RelatoriosDbContext _context;

    public AlunoSnapshotRepository(RelatoriosDbContext context)
    {
        _context = context;
    }

    public async Task<AlunoSnapshot?> ObterPorIdAsync(
        Guid alunoId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Alunos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == alunoId, cancellationToken);
    }

    public async Task<IReadOnlyCollection<AlunoSnapshot>> ObterTodosAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Alunos
            .AsNoTracking()
            .OrderBy(x => x.Nome)
            .ToListAsync(cancellationToken);
    }
}