using MediCareApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCareApi.Repository.Context.Maps;

public class UsuarioMap : BaseEntityMap<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Senha)
            .IsRequired();

        builder.HasOne(x => x.Pessoa)
            .WithOne(x => x.Usuario)
            .HasForeignKey<Usuario>(x => x.PessoaId);
    }
}