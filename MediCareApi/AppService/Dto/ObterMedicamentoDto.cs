namespace MediCareApi.AppService.Dto;

public class ObterMedicamentoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public string Dosagem { get; set; }
    public string? Horario { get; set; }
    public string? TempoDeTratamento { get; set; }
    public string? DataRegistro { get; set; }
}