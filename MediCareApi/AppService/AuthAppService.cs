using System.Net;
using MediCareApi.AppService.Dto;
using MediCareApi.AppService.ViewModel;
using MediCareApi.Entities;
using MediCareApi.Jwt;
using MediCareApi.Repository.Context;
using Microsoft.AspNetCore.Identity;

namespace MediCareApi.AppService;

public class AuthAppService
{
    private AppDbContext _context;
    public AuthAppService()
    {
        _context = new AppDbContext();
    }

    public CadastrarUsuarioViewModel CadastrarUsuario(CadastrarUsuarioDto dto)
    {
        if (dto.Senha != dto.SenhaConfirmacao)
        {
            throw new BadHttpRequestException("As senhas informadas não são correspondentes.", 
                (int) HttpStatusCode.BadRequest);
        }
        
        var usuarioExistente = _context.Usuarios.FirstOrDefault(x => x.Email == dto.Email);

        if (usuarioExistente != null)
        {
            throw new BadHttpRequestException("O email informado já está cadastrado no sistema.", 
                (int) HttpStatusCode.BadRequest);
        }
        
        var pessoa = new Pessoa
        {
            Nome = dto.Nome,
            Sobrenome = dto.Sobrenome,
        };

        var passwordHash = new PasswordHasher<Usuario>();
        
        var usuario = new Usuario
        {
            Email = dto.Email,
            Pessoa = pessoa
        };

        usuario.Senha = passwordHash.HashPassword(usuario, dto.Senha);
        
        _context.Usuarios.Add(usuario);
        
        _context.SaveChanges();

        return new CadastrarUsuarioViewModel()
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Nome = pessoa.Nome,
            Sobrenome = pessoa.Sobrenome,
        };
    }

    public LoginViewModel Login(LoginDto dto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == dto.Email);
        
        if (usuario == null)
        {
            throw new BadHttpRequestException("O usuário informado não existe no sistema.", 
                (int) HttpStatusCode.BadRequest);
        }
        
        var passwordHash = new PasswordHasher<Usuario>();
        
        var senhaValida = passwordHash.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);

        if (senhaValida == PasswordVerificationResult.Failed)
        {
            throw new BadHttpRequestException("A senha informada não coincide com a cadastrada no sistema.", 
                (int) HttpStatusCode.BadRequest);
        }
        
        var token = TokenService.GenerateToken(usuario);

        return new LoginViewModel
        {
            Token = token
        };
    }
}