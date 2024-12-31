namespace MediCareApi.AppService.Dto;

public class CadastrarAgendamentoDto
{
    public string Horario { get; set; }
    public string Frequencia { get; set; }
    public Guid MedicamentoId { get; set; }
}