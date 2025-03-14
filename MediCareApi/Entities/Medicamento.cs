namespace MediCareApi.Entities;

public class Medicamento : BaseEntity
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public string Dosagem { get; set; }
    public string? Horario { get; set; }
    public string? TempoDeTratamento { get; set; }
    public string? DataRegistro { get; set; }

    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public IEnumerable<Agendamento> Agendamentos { get; set; }

}