using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class valor_fijo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "valor_fijo",
                table: "Ingresos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor_fijo",
                table: "Ingresos");
        }
    }
}
