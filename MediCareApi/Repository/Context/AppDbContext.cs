using MediCareApi.Entities;
using MediCareApi.Repository.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace MediCareApi.Repository.Context;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost " +
            "Port=5432;" +
            "Database=postgres;" +
            "Uid=admin;" +
            "Pwd=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PessoaMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}