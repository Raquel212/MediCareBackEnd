using System.Net;
using MediCareApi.AppService.Dto;
using MediCareApi.Entities;
using MediCareApi.Repository.Context;

namespace MediCareApi.AppService;

public class MedicamentoAppService
{
    private UserAcessor Acessor { get; set; }
    private AppDbContext _context;

    public MedicamentoAppService()
    {
        Acessor = new UserAcessor();
        _context = new AppDbContext();
    }

    public CadastrarMedicamentoDto CadastrarMedicamento(CadastrarMedicamentoDto dto)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        var medicamentoExistente = _context.Medicamentos.FirstOrDefault(x => x.Nome == dto.Nome &&
                                                                             x.Dosagem == dto.Dosagem &&
                                                                             x.UsuarioId == usuarioId);

        if (medicamentoExistente != null)
        {
            throw new BadHttpRequestException("O medicamento informado já foi cadastrado.",
                (int)HttpStatusCode.BadRequest);
        }

        var medicamento = new Medicamento
        {
            Nome = dto.Nome,
            Dosagem = dto.Dosagem,
            Quantidade = dto.Quantidade,
            Horario = dto.Horario,
            UsuarioId = usuarioId
        };
        
        _context.Medicamentos.Add(medicamento);
        _context.SaveChanges();

        return new CadastrarMedicamentoDto
        {
            Nome = medicamento.Nome,
            Quantidade = medicamento.Quantidade,
            Dosagem = medicamento.Dosagem,
            Horario = medicamento.Horario,
        };
    }
}