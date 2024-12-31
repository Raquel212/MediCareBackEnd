using MediCareApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCareApi.Repository.Context.Maps;

public class AgendamentoMap: BaseEntityMap<Agendamento>
{
    public override void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Horario)
            .IsRequired();
        
        builder.Property(e => e.Frequencia)
            .IsRequired();
        
        builder.HasOne(e => e.Medicamento)
            .WithMany(e => e.Agendamentos)
            .HasForeignKey(e => e.MedicamentoId);
        
        builder.ToTable("Agendamento", "MediCare");
    }
}