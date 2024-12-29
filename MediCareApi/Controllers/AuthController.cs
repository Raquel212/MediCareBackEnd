using System.Net;
using MediCareApi.AppService;
using MediCareApi.AppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCareApi.Controllers;

[Route("Authentication/")]
[ApiController]
public class AuthController : ControllerBase
{
    private AuthAppService _appService;

    public AuthController()
    {
        _appService = new AuthAppService();
    }
    
    [HttpPost]
    public ActionResult RegistrarUsuario([FromBody] CadastrarUsuarioDto dto)
    {
        try
        {
            var result = _appService.CadastrarUsuario(dto);
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
    
    [HttpPost]
    [Route("login")]
    public ActionResult Authenticate([FromBody] LoginDto dto)
    {
        try
        {
            var result = _appService.Login(dto);
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

    [HttpGet]
    [Authorize]
    public ActionResult TesteLogin()
    {
        return Ok("Autenticado");
    }
}