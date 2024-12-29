﻿using System.ComponentModel.DataAnnotations;

namespace MediCareApi.Entities;

public class Usuario : BaseEntity
{
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    public string Senha { get; set; }
    
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    
    public IEnumerable<Medicamento> Medicamentos { get; set; }
}