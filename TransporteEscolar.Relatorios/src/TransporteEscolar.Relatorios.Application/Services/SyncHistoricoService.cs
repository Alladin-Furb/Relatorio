using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Application.Services;

public class SyncHistoricoService : ISyncHistoricoService
{
    public Task<SyncResultDto> ImportarPresencasAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new SyncResultDto
        {
            Operacao = "Importação de presenças",
            RegistrosProcessados = 0,
            Sucesso = true,
            Mensagem = $"Stub executado para o período {dataInicio:yyyy-MM-dd} até {dataFim:yyyy-MM-dd}."
        });
    }

    public Task<SyncResultDto> ImportarRotasAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new SyncResultDto
        {
            Operacao = "Importação de rotas",
            RegistrosProcessados = 0,
            Sucesso = true,
            Mensagem = $"Stub executado para o período {dataInicio:yyyy-MM-dd} até {dataFim:yyyy-MM-dd}."
        });
    }

    public Task<SyncResultDto> ImportarAlunosAsync(
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new SyncResultDto
        {
            Operacao = "Importação de alunos",
            RegistrosProcessados = 0,
            Sucesso = true,
            Mensagem = "Stub executado com sucesso."
        });
    }

    public Task<SyncResultDto> ImportarPeriodoAsync(
        DateOnly dataInicio,
        DateOnly dataFim,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new SyncResultDto
        {
            Operacao = "Importação consolidada por período",
            RegistrosProcessados = 0,
            Sucesso = true,
            Mensagem = $"Stub executado para o período {dataInicio:yyyy-MM-dd} até {dataFim:yyyy-MM-dd}."
        });
    }
}