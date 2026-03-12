using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Api.Controllers;

[ApiController]
[Route("api/indicadores")]
public class IndicadoresController : ControllerBase
{
    private readonly IIndicadorOperacionalService _indicadorOperacionalService;

    public IndicadoresController(IIndicadorOperacionalService indicadorOperacionalService)
    {
        _indicadorOperacionalService = indicadorOperacionalService;
    }

    [HttpGet("operacionais")]
    [ProducesResponseType(typeof(IndicadorOperacionalDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetIndicadoresOperacionais(
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _indicadorOperacionalService.ObterAsync(ano, mes, cancellationToken);
        return Ok(resultado);
    }
}