using TransporteEscolar.Relatorios.Domain.Entities;

namespace TransporteEscolar.Relatorios.Application.Abstractions;

public interface IAlunoSnapshotRepository
{
    Task<AlunoSnapshot?> ObterPorIdAsync(
        Guid alunoId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<AlunoSnapshot>> ObterTodosAsync(
        CancellationToken cancellationToken = default);
}