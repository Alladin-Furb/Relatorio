using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;
using TransporteEscolar.Relatorios.Application.Exceptions;

namespace TransporteEscolar.Relatorios.Api.Controllers;

[ApiController]
[Route("api/sync")]
public class SyncController : ControllerBase
{
    private readonly ISyncHistoricoService _syncHistoricoService;

    public SyncController(ISyncHistoricoService syncHistoricoService)
    {
        _syncHistoricoService = syncHistoricoService;
    }

    [HttpPost("presencas")]
    [ProducesResponseType(typeof(SyncResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SyncPresencas(
        [FromQuery] DateOnly dataInicio,
        [FromQuery] DateOnly dataFim,
        CancellationToken cancellationToken)
    {
        if (dataFim < dataInicio)
            return BadRequest("Período inválido.");

        var resultado = await _syncHistoricoService.ImportarPresencasAsync(dataInicio, dataFim, cancellationToken);
        return Ok(resultado);
    }

    [HttpPost("rotas")]
    [ProducesResponseType(typeof(SyncResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SyncRotas(
        [FromQuery] DateOnly dataInicio,
        [FromQuery] DateOnly dataFim,
        CancellationToken cancellationToken)
    {
        if (dataFim < dataInicio)
            throw new BusinessException("Período inválido.");

        var resultado = await _syncHistoricoService.ImportarRotasAsync(dataInicio, dataFim, cancellationToken);
        return Ok(resultado);
    }

    [HttpPost("alunos")]
    [ProducesResponseType(typeof(SyncResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SyncAlunos(CancellationToken cancellationToken)
    {
        var resultado = await _syncHistoricoService.ImportarAlunosAsync(cancellationToken);
        return Ok(resultado);
    }

    [HttpPost("periodo")]
    [ProducesResponseType(typeof(SyncResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SyncPeriodo(
        [FromQuery] DateOnly dataInicio,
        [FromQuery] DateOnly dataFim,
        CancellationToken cancellationToken)
    {
        if (dataFim < dataInicio)
            throw new BusinessException("Período inválido.");

        var resultado = await _syncHistoricoService.ImportarPeriodoAsync(dataInicio, dataFim, cancellationToken);
        return Ok(resultado);
    }
}