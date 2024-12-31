using System.Net;
using MediCareApi.AppService;
using MediCareApi.AppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCareApi.Controllers;

[Route("Agendamento/")]
[ApiController]
public class AgendamentoController : ControllerBase
{
    private AgendamentoAppService _appService;

    public AgendamentoController()
    {
        _appService = new AgendamentoAppService();
    }

    [HttpPost]
    [Authorize]
    public ActionResult CadastrarAgendamento([FromBody] CadastrarAgendamentoDto dto)
    {
        try
        {
            _appService.CadastrarAgendamento(dto);
            return Created();
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

    [HttpGet]
    [Authorize]
    public ActionResult ListarMedicamentos([FromQuery] int pagina = 1, [FromQuery] int quantidadePorPagina = 10)
    {
        try
        {
            var result = _appService.ListarMedicamentos();
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
}