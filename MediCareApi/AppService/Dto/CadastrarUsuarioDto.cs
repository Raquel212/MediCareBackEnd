using System.ComponentModel.DataAnnotations;

namespace MediCareApi.AppService.Dto;

public class CadastrarUsuarioDto
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    public required string Nome { get; set; }
    
    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    public required string Sobrenome { get; set; }
    
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    public required string Senha { get; set; }
}