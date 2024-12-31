using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCareApi.Migrations
{
    /// <inheritdoc />
    public partial class adiciona_campo_frequencia_agendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Frequencia",
                schema: "MediCare",
                table: "Agendamento",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequencia",
                schema: "MediCare",
                table: "Agendamento");
        }
    }
}
