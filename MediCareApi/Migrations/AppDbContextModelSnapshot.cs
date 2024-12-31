﻿// <auto-generated />
using System;
using MediCareApi.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MediCareApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MediCareApi.Entities.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicamentoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoId");

                    b.ToTable("Agendamento", "MediCare");
                });

            modelBuilder.Entity("MediCareApi.Entities.Medicamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Dosagem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Horario")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Medicamento", "MediCare");
                });

            modelBuilder.Entity("MediCareApi.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", "MediCare");
                });

            modelBuilder.Entity("MediCareApi.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Usuario", "MediCare");
                });

            modelBuilder.Entity("MediCareApi.Entities.Agendamento", b =>
                {
                    b.HasOne("MediCareApi.Entities.Medicamento", "Medicamento")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("MediCareApi.Entities.Medicamento", b =>
                {
                    b.HasOne("MediCareApi.Entities.Usuario", "Usuario")
                        .WithMany("Medicamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MediCareApi.Entities.Usuario", b =>
                {
                    b.HasOne("MediCareApi.Entities.Pessoa", "Pessoa")
                        .WithOne("Usuario")
                        .HasForeignKey("MediCareApi.Entities.Usuario", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("MediCareApi.Entities.Medicamento", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("MediCareApi.Entities.Pessoa", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("MediCareApi.Entities.Usuario", b =>
                {
                    b.Navigation("Medicamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
