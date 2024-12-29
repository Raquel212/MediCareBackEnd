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

}