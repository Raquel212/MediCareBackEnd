using MediCareApi.AppService.Dto;
using MediCareApi.AppService.ViewModel;
using MediCareApi.Entities;
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
        var pessoa = new Pessoa()
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
}