using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Relatorios.Application.Abstractions;
using TransporteEscolar.Relatorios.Application.DTOs;

namespace TransporteEscolar.Relatorios.Api.Controllers;

[ApiController]
[Route("api/relatorios")]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioMensalService _relatorioMensalService;

    public RelatoriosController(IRelatorioMensalService relatorioMensalService)
    {
        _relatorioMensalService = relatorioMensalService;
    }

    [HttpGet("mensal")]
    [ProducesResponseType(typeof(RelatorioMensalDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRelatorioMensal(
        [FromQuery] int ano,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        if (ano <= 0 || mes < 1 || mes > 12)
            return BadRequest("Ano ou mês inválido.");

        var resultado = await _relatorioMensalService.GerarAsync(ano, mes, cancellationToken);
        return Ok(resultado);
    }
}