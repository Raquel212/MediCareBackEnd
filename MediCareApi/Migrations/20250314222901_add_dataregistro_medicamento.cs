using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCareApi.Migrations
{
    /// <inheritdoc />
    public partial class add_dataregistro_medicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataRegistro",
                schema: "MediCare",
                table: "Medicamento",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegistro",
                schema: "MediCare",
                table: "Medicamento");
        }
    }
}
