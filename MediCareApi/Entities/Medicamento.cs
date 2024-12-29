namespace MediCareApi.Entities;

public class Medicamento : BaseEntity
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public string Dosagem { get; set; }
    public string? Horario { get; set; }
    
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}