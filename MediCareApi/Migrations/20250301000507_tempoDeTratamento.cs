using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCareApi.Migrations
{
    /// <inheritdoc />
    public partial class tempoDeTratamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempoDeTratamento",
                schema: "MediCare",
                table: "Medicamento",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoDeTratamento",
                schema: "MediCare",
                table: "Medicamento");
        }
    }
}
