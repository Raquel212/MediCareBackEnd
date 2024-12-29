using MediCareApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCareApi.Repository.Context.Maps;

public class MedicamentoMap : BaseEntityMap<Medicamento>
{
    public override void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        base.Configure(builder);
        
        builder.Property(e => e.Nome)
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(e => e.Quantidade)
            .IsRequired();

        builder.Property(e => e.Dosagem)
            .IsRequired();

        builder.Property(e => e.Horario);

        builder.HasOne(e => e.Usuario)
            .WithMany(e => e.Medicamentos)
            .HasForeignKey(e => e.UsuarioId);
    }
}