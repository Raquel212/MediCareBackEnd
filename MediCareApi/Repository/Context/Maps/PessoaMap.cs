using MediCareApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCareApi.Repository.Context.Maps;

public class PessoaMap : BaseEntityMap<Pessoa>
{
    public override void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Sobrenome)
            .HasMaxLength(50)
            .IsRequired();
    }
}