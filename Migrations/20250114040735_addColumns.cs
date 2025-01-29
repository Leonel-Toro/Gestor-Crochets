using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class addColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vuelta",
                table: "Patron",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "forma_venta",
                table: "Ingresos",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<int>(
                name: "valor_entrega",
                table: "Ingresos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valor_hora",
                table: "Ingresos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "eliminado",
                table: "CostoMaterial",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vuelta",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "valor_entrega",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "valor_hora",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "eliminado",
                table: "CostoMaterial");

            migrationBuilder.AlterColumn<bool>(
                name: "forma_venta",
                table: "Ingresos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
