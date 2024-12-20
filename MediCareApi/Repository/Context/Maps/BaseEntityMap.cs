using MediCareApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCareApi.Repository.Context.Maps;

public class BaseEntityMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}