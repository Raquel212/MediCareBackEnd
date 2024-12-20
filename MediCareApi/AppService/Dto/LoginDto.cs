using System.ComponentModel.DataAnnotations;

namespace MediCareApi.AppService.Dto;

public class LoginDto
{
    [EmailAddress(ErrorMessage = "O email informado é invalido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }
}