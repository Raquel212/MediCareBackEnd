using System.ComponentModel.DataAnnotations;

namespace MediCareApi.AppService.Dto;

public class CadastrarMedicamentoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "A dosagem é obrigatória.")]
    public string Dosagem { get; set; }
    public string? Horario { get; set; }
    public string? TempoDeTratamento { get; set; }
}