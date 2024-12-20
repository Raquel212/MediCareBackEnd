using MediCareApi.AppService.Dto;
using MediCareApi.AppService.ViewModel;
using MediCareApi.Entities;
using MediCareApi.Repository.Context;

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

        var usuario = new Usuario()
        {
            Email = dto.Email,
            Senha = dto.Senha,
            Pessoa = pessoa
        };
        
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