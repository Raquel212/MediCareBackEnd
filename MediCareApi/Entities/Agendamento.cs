namespace MediCareApi.Entities;

public class Agendamento : BaseEntity
{
    public string Horario { get; set; }
    public string Frequencia { get; set; }
    
    public Guid MedicamentoId { get; set; }
    public Guid UsuarioId { get; set; }
    public Medicamento Medicamento { get; set; }
}