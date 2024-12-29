using System.Net;
using MediCareApi.AppService;
using MediCareApi.AppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCareApi.Controllers;

[Route("Medicamento/")]
[ApiController]
public class MedicamentoController : ControllerBase
{
    private MedicamentoAppService _appService;

    public MedicamentoController()
    {
        _appService = new MedicamentoAppService();
    }

    [HttpPost]
    [Authorize]
    public ActionResult CadastrarMedicamento([FromBody] CadastrarMedicamentoDto dto)
    {
        try
        {
            var result = _appService.CadastrarMedicamento(dto);
            return Created(string.Empty, result);
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                errors = e.Message
            });
        }
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public ActionResult ObterMedicamento([FromRoute] Guid id)
    {
        try
        {
            var result = _appService.ObterMedicamento(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                status = HttpStatusCode.BadRequest,
                errors = e.Message
            });
        }
    }

    [HttpGet]
    [Authorize]
    public ActionResult ListarMedicamentos([FromQuery] int pagina = 1, [FromQuery] int quantidadePorPagina = 10)
    {
        try
        {
            var result = _appService.ListarMedicamentos(pagina, quantidadePorPagina);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                errors = e.Message
            });
        }
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public ActionResult AtualizarMedicamento([FromRoute] Guid id, [FromBody] CadastrarMedicamentoDto medicamentoDto)
    {
        try
        {
            var result = _appService.AtualizarMedicamento(id, medicamentoDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                status = HttpStatusCode.NotFound,
                errors = e.Message
            });
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public ActionResult ExcluirMedicamento([FromRoute] Guid id)
    {
        try
        {
            _appService.ExcluirMedicamento(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                status = HttpStatusCode.NotFound,
                errors = e.Message
            });
        }
    }
}