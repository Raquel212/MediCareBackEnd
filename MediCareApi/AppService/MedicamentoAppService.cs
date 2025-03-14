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

    public ObterMedicamentoDto CadastrarMedicamento(CadastrarMedicamentoDto dto)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        var medicamentoExistente = _context.Medicamentos.FirstOrDefault(x => x.Nome.ToUpper() == dto.Nome.ToUpper() &&
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
            UsuarioId = usuarioId,
            TempoDeTratamento = dto.TempoDeTratamento,
            DataRegistro = dto.DataRegistro
        };

        _context.Medicamentos.Add(medicamento);
        _context.SaveChanges();

        return new ObterMedicamentoDto
        {
            Id = medicamento.Id,
            Nome = medicamento.Nome,
            Quantidade = medicamento.Quantidade,
            Dosagem = medicamento.Dosagem,
            Horario = medicamento.Horario,
            TempoDeTratamento = medicamento.TempoDeTratamento
        };
    }

    public ObterMedicamentoDto ObterMedicamento(Guid id)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        var medicamentoExistente = _context.Medicamentos.FirstOrDefault(x => x.Id == id &&
                                                                             x.UsuarioId == usuarioId);

        if (medicamentoExistente == null)
        {
            throw new BadHttpRequestException("O medicamento não foi encontrado",
                (int)HttpStatusCode.BadRequest);
        }

        return new ObterMedicamentoDto
        {
            Id = medicamentoExistente.Id,
            Nome = medicamentoExistente.Nome,
            Quantidade = medicamentoExistente.Quantidade,
            Dosagem = medicamentoExistente.Dosagem,
            Horario = medicamentoExistente.Horario,
            TempoDeTratamento = medicamentoExistente.TempoDeTratamento,
            DataRegistro = medicamentoExistente.DataRegistro
        };
    }

    public List<ObterMedicamentoDto> ListarMedicamentos(int pagina = 1, int quantidadePorPagina = 10)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        if (pagina <= 0) pagina = 1;
        if (quantidadePorPagina <= 0) quantidadePorPagina = 10;

        var skip = (pagina - 1) * quantidadePorPagina;

        var medicamentos = _context.Medicamentos
            .Where(x => x.UsuarioId == usuarioId)
            .Skip(skip)
            .Take(quantidadePorPagina)
            .ToList();

        if (medicamentos.Count == 0)
        {
            throw new BadHttpRequestException("Nenhum medicamento encontrado para a página solicitada",
                (int)HttpStatusCode.NotFound);
        }

        var medicamentosDto = medicamentos.Select(m => new ObterMedicamentoDto
        {
            Id = m.Id,
            Nome = m.Nome,
            Quantidade = m.Quantidade,
            Dosagem = m.Dosagem,
            Horario = m.Horario,
            TempoDeTratamento = m.TempoDeTratamento,
            DataRegistro = m.DataRegistro
        }).ToList();

        return medicamentosDto;
    }

    public ObterMedicamentoDto AtualizarMedicamento(Guid id, CadastrarMedicamentoDto medicamentoDto)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        var medicamentoExistente = _context.Medicamentos
            .FirstOrDefault(x => x.Id == id && x.UsuarioId == usuarioId);

        if (medicamentoExistente == null)
        {
            throw new BadHttpRequestException("Medicamento não encontrado", (int)HttpStatusCode.NotFound);
        }

        medicamentoExistente.Nome = medicamentoDto.Nome;
        medicamentoExistente.Quantidade = medicamentoDto.Quantidade;
        medicamentoExistente.Dosagem = medicamentoDto.Dosagem;
        medicamentoExistente.Horario = medicamentoDto.Horario;
        medicamentoExistente.TempoDeTratamento = medicamentoDto.TempoDeTratamento;
        medicamentoExistente.DataRegistro = medicamentoDto.DataRegistro;

        _context.Medicamentos.Update(medicamentoExistente);
        _context.SaveChanges();

        return new ObterMedicamentoDto
        {
            Id = medicamentoExistente.Id,
            Nome = medicamentoExistente.Nome,
            Quantidade = medicamentoExistente.Quantidade,
            Dosagem = medicamentoExistente.Dosagem,
            Horario = medicamentoExistente.Horario,
            TempoDeTratamento = medicamentoExistente.TempoDeTratamento
        };
    }
    
    public void ExcluirMedicamento(Guid id)
    {
        var usuarioId = Acessor.ObterIdUsuario();

        var medicamentoExistente = _context.Medicamentos
            .FirstOrDefault(x => x.Id == id && x.UsuarioId == usuarioId);

        if (medicamentoExistente == null)
        {
            throw new BadHttpRequestException("Medicamento não encontrado", (int)HttpStatusCode.NotFound);
        }

        _context.Medicamentos.Remove(medicamentoExistente);
        _context.SaveChanges();
    }
}