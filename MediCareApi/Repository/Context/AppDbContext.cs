using MediCareApi.Entities;
using MediCareApi.Repository.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace MediCareApi.Repository.Context;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Host=ep-fancy-moon-a8y2j5fp-pooler.eastus2.azure.neon.tech;" +
                          "Database=neondb;" +
                          "Username=neondb_owner;" +
                          "Password=npg_2bINOB7ryvLT;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PessoaMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new MedicamentoMap());
        modelBuilder.ApplyConfiguration(new AgendamentoMap());
    }
}