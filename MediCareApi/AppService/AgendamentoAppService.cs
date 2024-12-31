using System.Net;
using MediCareApi.AppService.Dto;
using MediCareApi.AppService.ViewModel;
using MediCareApi.Entities;
using MediCareApi.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCareApi.AppService;

public class AgendamentoAppService
{
    private UserAcessor Acessor { get; set; }
    private AppDbContext _context;

    public AgendamentoAppService()
    {
        Acessor = new UserAcessor();
        _context = new AppDbContext();
    }

    public void CadastrarAgendamento(CadastrarAgendamentoDto dto)
    {
        var usuarioId = Acessor.ObterIdUsuario();
        
        var agendamento = new Agendamento()
        {
            Horario = dto.Horario,
            MedicamentoId = dto.MedicamentoId,
            UsuarioId = usuarioId
        };

        _context.Agendamentos.Add(agendamento);
        _context.SaveChanges();
    }

    public IEnumerable<ObterAgendamentosViewModel> ListarAgendamentos(int pagina = 1, int quantidadePorPagina = 10)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        if (pagina <= 0) pagina = 1;
        if (quantidadePorPagina <= 0) quantidadePorPagina = 10;

        var skip = (pagina - 1) * quantidadePorPagina;

        var medicamentos = _context.Agendamentos
            .Include(x => x.Medicamento)
            .Where(x => x.UsuarioId == usuarioId)
            .Skip(skip)
            .Take(quantidadePorPagina)
            .ToList();

        if (medicamentos.Count == 0)
        {
            throw new BadHttpRequestException("Nenhum agendamento encontrado para a página solicitada",
                (int)HttpStatusCode.NotFound);
        }

        var medicamentosDto = medicamentos.Select(m => new ObterAgendamentosViewModel
        {
            Medicamento = m.Medicamento.Nome,
            Horario = m.Horario,
            
        }).ToList();

        return medicamentosDto;
    }
}