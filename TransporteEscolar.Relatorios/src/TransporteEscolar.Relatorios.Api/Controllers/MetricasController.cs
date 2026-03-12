using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Api.Controllers;

[ApiController]
[Route("api/metricas")]
public class MetricasController : ControllerBase
{
    private readonly IFrequenciaAlunoService _frequenciaAlunoService;
    private readonly IKmService _kmService;

    public MetricasController(
        IFrequenciaAlunoService frequenciaAlunoService,
        IKmService kmService)
    {
        _frequenciaAlunoService = frequenciaAlunoService;
        _kmService = kmService;
    }

    [HttpGet("frequencia/alunos/{alunoId:guid}")]
    [ProducesResponseType(typeof(FrequenciaAlunoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFrequenciaAluno(
        [FromRoute] Guid alunoId,
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (alunoId == Guid.Empty)
            return BadRequest("Aluno inválido.");

        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _frequenciaAlunoService.CalcularAsync(alunoId, ano, mes, cancellationToken);
        return Ok(resultado);
    }

    [HttpGet("frequencia/alunos")]
    [ProducesResponseType(typeof(IReadOnlyCollection<FrequenciaAlunoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFrequenciaAlunos(
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _frequenciaAlunoService.CalcularTodosAsync(ano, mes, cancellationToken);
        return Ok(resultado);
    }

    [HttpGet("km/media-diaria")]
    [ProducesResponseType(typeof(MediaKmDiariaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMediaKmDiaria(
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _kmService.ObterMediaDiariaAsync(ano, mes, cancellationToken);
        return Ok(resultado);
    }

    [HttpGet("km/por-dia")]
    [ProducesResponseType(typeof(IReadOnlyCollection<KmPorDiaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetKmPorDia(
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _kmService.ObterPorDiaAsync(ano, mes, cancellationToken);
        return Ok(resultado);
    }
}