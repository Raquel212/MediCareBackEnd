﻿using MediCareApi.AppService;
using MediCareApi.AppService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MediCareApi.Controllers;

[Route("Authentication/")]
public class AuthController : ControllerBase
{
    private AuthAppService _appService;

    public AuthController()
    {
        _appService = new AuthAppService();
    }

    /// <summary>
    /// Cria um usuário.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Usuário criado.</returns>
    [HttpPost]
    public ActionResult RegistrarUsuario([FromBody] CadastrarUsuarioDto dto)
    {
        var result = _appService.CadastrarUsuario(dto);

        return Created(string.Empty, result);
    }
}