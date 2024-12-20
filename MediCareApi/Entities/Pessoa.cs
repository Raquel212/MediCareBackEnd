using System.ComponentModel.DataAnnotations;

namespace MediCareApi.Entities;

public class Pessoa : BaseEntity
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    public required string Nome { get; set; }
    
    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    public required string Sobrenome { get; set; }
    
    public Usuario Usuario { get; set; }
}