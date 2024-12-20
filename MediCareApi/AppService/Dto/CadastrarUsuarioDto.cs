using System.ComponentModel.DataAnnotations;

namespace MediCareApi.AppService.Dto;

public class CadastrarUsuarioDto
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    public string Senha { get; set; }
}