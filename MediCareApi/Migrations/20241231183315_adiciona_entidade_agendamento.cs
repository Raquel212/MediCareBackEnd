using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCareApi.Migrations
{
    /// <inheritdoc />
    public partial class adiciona_entidade_agendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamento",
                schema: "MediCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Horario = table.Column<string>(type: "text", nullable: false),
                    MedicamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalSchema: "MediCare",
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_MedicamentoId",
                schema: "MediCare",
                table: "Agendamento",
                column: "MedicamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento",
                schema: "MediCare");
        }
    }
}
