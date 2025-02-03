using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftBorrados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgRuta",
                table: "Producto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "borrado",
                table: "Ingresos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "productoVendidoId",
                table: "Ingresos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_productoVendidoId",
                table: "Ingresos",
                column: "productoVendidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Producto_productoVendidoId",
                table: "Ingresos",
                column: "productoVendidoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Producto_productoVendidoId",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_productoVendidoId",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "ImgRuta",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "borrado",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "productoVendidoId",
                table: "Ingresos");
        }
    }
}
